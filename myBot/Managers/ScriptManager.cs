using MoonSharp.Interpreter;
using MoonSharp.Interpreter.Interop;
using myBot.Objects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace myBot.Managers
{
    public enum ProcWindowStyle
    {
        Hidden,
        Maximized,
        Minimized,
        Normal,
    }

    [MoonSharpUserData]
    public class ScriptManager
    {
        [MoonSharpVisible(false)]
        public void SetupApi(ref Script script)
        {
            script.Globals["FILE_NAME"] = Path.GetFileName(Manager.ScriptPath);

            script.Globals["LOCAL_PATH"] = Manager.ExePath;
            script.Globals["SCRIPT_PATH"] = Manager.ScriptsPath;
            script.Globals["LIB_PATH"] = Manager.LibsPath;
            script.Globals["SAVE_PATH"] = Manager.SavesPath;

            script.Globals["WINDOW_STYLE_HIDDEN"] = ProcWindowStyle.Hidden;
            script.Globals["WINDOW_STYLE_MAXIMIZED"] = ProcWindowStyle.Maximized;
            script.Globals["WINDOW_STYLE_MINIMIZED"] = ProcWindowStyle.Minimized;
            script.Globals["WINDOW_STYLE_NORMAL"] = ProcWindowStyle.Normal;

            script.Globals["ZIP_MODE_CREATE"] = ZipArchiveMode.Create;
            script.Globals["ZIP_MODE_READ"] = ZipArchiveMode.Read;
            script.Globals["ZIP_MPDE_UPDATE"] = ZipArchiveMode.Update;

            script.Globals["ZIP_COMPRESSION_FAST"] = CompressionLevel.Fastest;
            script.Globals["ZIP_COMPRESSION_NONE"] = CompressionLevel.NoCompression;
            script.Globals["ZIP_COMPRESSION_OPTIMAL"] = CompressionLevel.Optimal;

            script.Globals["Wait"] = (Action<int>)Thread.Sleep;
            script.Globals["StopScript"] = (Action)(() => { throw new StopScriptException(); });

            script.Globals["StartProcess"] = (Func<string, string, cProcess>)StartProcess;
            script.Globals["NewProcess"] = (Func<string, string, cProcessStartInfo>)NewProcess;
            script.Globals["GetCurrentProcess"] = (Func<cProcess>)(() => { return new cProcess(Process.GetCurrentProcess()); });
            script.Globals["GetProcesses"] = (Func<string, cProcess[]>)GetProcesses;
            script.Globals["GetProcessById"] = (Func<int, string, cProcess>)GetProcessById;
            script.Globals["GetProcessesByName"] = (Func<string, string, cProcess[]>)GetProcessesByName;

            script.Globals["FileExists"] = (Func<string, bool>)File.Exists;
            script.Globals["ReadFile"] = (Func<string, string[]>)File.ReadAllLines;
            script.Globals["CreateFile"] = (Action<string>)CreateFile;
            script.Globals["DeleteFile"] = (Func<string, bool>)DeleteFile;
            script.Globals["GetFiles"] = (Func<string, string, bool, string[]>)GetFiles;
            script.Globals["GetFileName"] = (Func<string, bool, string>)GetFileName;

            script.Globals["GetWebResult"] = (Func<string, string, string>)GetWebResult;
            script.Globals["DownloadFile"] = (Action<string, string, string, DynValue>)DownloadFile;

            script.Globals["Base64Encode"] = (Func<string, string>)Base64Encode;
            script.Globals["Base64Decode"] = (Func<string, string>)Base64Decode;

            script.Globals["StartsWith"] = (Func<string, string, bool>)((input, match) => { return input.StartsWith(match); });
            script.Globals["Split"] = (Func<string, string, string[]>)((input, splitter) => { return input.Split(new string[] { splitter }, StringSplitOptions.None); });
            script.Globals["Trim"] = (Func<string, string>)((s) => { return s.Trim(); });
            script.Globals["TrimStart"] = (Func<string, string>)((s) => { return s.TrimStart(); });
            script.Globals["TrimEnd"] = (Func<string, string>)((s) => { return s.TrimEnd(); });
            script.Globals["StringIsEmpty"] = (Func<string, bool, bool>)StringIsEmpty;
        }

        private void CreateFile(string path)
        {
            StreamWriter sw = File.CreateText(path);

            sw.Close();
            sw.Dispose();
        }

        private bool DeleteFile(string path)
        {
            try
            {
                File.Delete(path);
            }
            catch (Exception ex)
            {
                FancyConsole.WriteLine(ex.Message, ConsoleColor.Red);
                return false;
            }

            return true;
        }

        private string Base64Encode(string text)
        {
            var bytes = Encoding.UTF8.GetBytes(text);
            return Convert.ToBase64String(bytes);
        }

        private string Base64Decode(string data)
        {
            var bytes = Convert.FromBase64String(data);
            return Encoding.UTF8.GetString(bytes);
        }

        private string[] GetFiles(string path, string pattern = "", bool allDirectories = false)
        {
            return Directory.GetFiles(path, (String.IsNullOrWhiteSpace(pattern)) ? "*" : pattern, (allDirectories) ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);
        }

        private string GetFileName(string path, bool keepExtension = true)
        {
            if (keepExtension)
                return Path.GetFileName(path);
            else
                return Path.GetFileNameWithoutExtension(path);
        }

        private string GetWebResult(string host, string path)
        {
            return GetWebResult(host + "/" + path);
        }

        private string GetWebResult(string url)
        {
            string data = String.Empty;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = null;

                if (response.CharacterSet == null)
                    readStream = new StreamReader(receiveStream);
                else
                    readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));

                data = readStream.ReadToEnd();

                receiveStream.Close();
                readStream.Close();
            }

            response.Close();

            return data;
        }

        private void DownloadFile(string host, string path, string localFile, DynValue callback)
        {
            DownloadFile(host + "/" + path, localFile, callback);
        }

        private void DownloadFile(string url, string localFile, DynValue callback)
        {
            bool downloaded = true;

            try
            {
                using (WebClient client = new WebClient())
                {
                    client.DownloadFile(url, localFile);
                }
            }
            catch (WebException ex)
            {
                FancyConsole.WriteLine(ex.Message, ConsoleColor.Red);
                downloaded = false;
            }

            if (!callback.IsNilOrNan())
                Program.Call(callback, downloaded);
        }

        private bool StringIsEmpty(string input, bool checkWhitespace = false)
        {
            if (checkWhitespace)
                return String.IsNullOrWhiteSpace(input);
            else
                return String.IsNullOrEmpty(input);
        }

        private cProcessStartInfo NewProcess(string path = "", string args = "")
        {
            return new cProcessStartInfo(new ProcessStartInfo(path, args));
        }

        private cProcess StartProcess(string path, string args = "")
        {
            return new cProcess(Process.Start(path, args));
        }

        private cProcess GetProcessById(int id, string machine = "")
        {
            if (String.IsNullOrWhiteSpace(machine))
                return new cProcess(Process.GetProcessById(id));
            else
                return new cProcess(Process.GetProcessById(id, machine));
        }

        private cProcess[] GetProcessesByName(string name, string machine = "")
        {
            Process[] procs = new Process[0];
            List<cProcess> nprocs = new List<cProcess>();

            if (String.IsNullOrWhiteSpace(machine))
                procs = Process.GetProcessesByName(name);
            else
                procs = Process.GetProcessesByName(name, machine);

            for (int i = 0; i < procs.Length; i++)
                nprocs.Add(new cProcess(procs[i]));

            return nprocs.ToArray();
        }

        private cProcess[] GetProcesses(string machine = "")
        {
            Process[] procs = new Process[0];
            List<cProcess> nprocs = new List<cProcess>();

            if (String.IsNullOrWhiteSpace(machine))
                procs = Process.GetProcesses();
            else
                procs = Process.GetProcesses(machine);

            for (int i = 0; i < procs.Length; i++)
                nprocs.Add(new cProcess(procs[i]));

            return nprocs.ToArray();
        }
    }
}
