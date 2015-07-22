using MoonSharp.Interpreter;
using MoonSharp.Interpreter.Loaders;
using myBot.Managers;
using System;
using System.IO;
using System.Reflection;
using WatiN.Core;

namespace myBot
{
    public static class Program
    {
        private static Script script;
        private static string scriptPath;

        private static ScriptManager scriptManager = new ScriptManager();
        private static ConsoleManager consoleManager = new ConsoleManager();
        private static BrowserManager browserManager = new BrowserManager();
        private static YoutubeManager youtubeManager = new YoutubeManager();

        public static void Call(DynValue callback, params object[] args)
        {
            Helpers.Run(() => script.Call(callback, args));
        }

        public static void SetGlobal(string name, DynValue value)
        {
            script.Globals.Set(name, value);
        }

        [STAThread]
        private static void Main(string[] args)
        {
            Console.Title = "myBot Studio";

            FancyConsole.WriteLine("Loading version " + Manager.AppVersion + "...", ConsoleColor.Gray);
            FancyConsole.WriteLine();
            FancyConsole.WriteLine("╔══╦══════════════════════════════════════════════════════════════════════╦══╗", ConsoleColor.Magenta);
            FancyConsole.WriteLine("║██║                        ╔════════════════════╗                        ║██║", ConsoleColor.Magenta);
            FancyConsole.WriteLine("║██║                        ║       myBot        ║                        ║██║", ConsoleColor.Magenta);
            FancyConsole.WriteLine("║██║                        ║ Programmed by Devn ║                        ║██║", ConsoleColor.Magenta);
            FancyConsole.WriteLine("║██║                        ╚════════════════════╝                        ║██║", ConsoleColor.Magenta);
            FancyConsole.WriteLine("╚══╩══════════════════════════════════════════════════════════════════════╩══╝", ConsoleColor.Magenta);
            FancyConsole.WriteLine();

            Initialize();
            CheckFolders();

            if (CheckForQuickLoad(args))
                return;

            ParseUserAction();
        }

        private static void Initialize()
        {
            Settings.MakeNewIeInstanceVisible = true;

            UserData.RegisterAssembly(Assembly.GetExecutingAssembly());
            Script.DefaultOptions.UseLuaErrorLocations = true;
        }

        private static void CheckFolders()
        {
            CheckFolder(Manager.ScriptsPath);
            CheckFolder(Manager.LibsPath);
            CheckFolder(Manager.SavesPath);
        }

        private static void CheckFolder(string path)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
        }

        private static bool CheckForQuickLoad(string[] args)
        {
            if (args.Length >= 1)
            {
                if (Helpers.IsValidScriptPath(args[0]))
                {
                    FancyConsole.WriteLine("Quick Load => Running script: " + args[0]);
                    FancyConsole.WriteLine();

                    scriptPath = args[0];
                    LoadScript();
                    AskToReset();
                    Close();
                    return true;
                }

                FancyConsole.WriteLine("Quick Load => No script found at location: " + args[0], ConsoleColor.Red);
                FancyConsole.WriteLine();
            }

            return false;
        }

        private static void ParseUserAction()
        {
            FancyConsole.WriteLine("Type 'help' for a list of commands...", ConsoleColor.Cyan);
            string cmd = FancyConsole.GetInput("What would you like to do: ").Trim().ToLower();

            switch (cmd)
            {
                case "r":
                case "run":
                    FancyConsole.WriteLine();
                    GetScriptToRun();
                    FancyConsole.WriteLine();
                    break;

                case "u":
                case "update":
                    FancyConsole.WriteLine();
                    FancyConsole.WriteLine("update => not implemented yet");
                    FancyConsole.WriteLine();
                    break;

                case "d":
                case "debug":
                    FancyConsole.WriteLine();
                    DebugMode();
                    FancyConsole.WriteLine();
                    break;

                case "h":
                case "help":
                    FancyConsole.WriteLine();
                    FancyConsole.WriteLine("Available console commands:", ConsoleColor.Cyan);
                    FancyConsole.WriteLine("    run    = Run a specified script.", ConsoleColor.Yellow);
                    FancyConsole.WriteLine("    update = Update application.", ConsoleColor.Yellow);
                    FancyConsole.WriteLine("    debug  = Enter debug mode to test Lua functions.", ConsoleColor.Yellow);
                    FancyConsole.WriteLine("    help   = Show all available console commands.", ConsoleColor.Yellow);
                    FancyConsole.WriteLine("    exit   = Exit application.", ConsoleColor.Yellow);
                    FancyConsole.WriteLine();
                    break;

                case "e":
                case "exit":
                case "":
                    Close();
                    return;

                default:
                    FancyConsole.WriteLine("Unknown command '" + cmd + "'...", ConsoleColor.Red);
                    FancyConsole.WriteLine();
                    break;
            }

            ParseUserAction();
        }

        private static void GetScriptToRun()
        {
            bool exit = false;

            scriptPath = String.Empty;
            string[] scripts = Directory.GetFiles(Path.Combine(Manager.ScriptsPath), "*.Lua");

            if (scripts.Length >= 1)
            {
                string format = (scripts.Length > 9) ? "00" : "0";

                while (true)
                {
                    FancyConsole.WriteLine("Enter the number to the desired script you want to run...");
                    FancyConsole.WriteLine("    " + (0).ToString(format) + " = Enter the path to a script to run...", ConsoleColor.Yellow);

                    for (int i = 0; i < scripts.Length; i++)
                        FancyConsole.WriteLine(String.Format("    {0} = ./{1}", (i + 1).ToString(format), Path.GetFileName(scripts[i])), ConsoleColor.Yellow);

                    FancyConsole.WriteLine();
                    string sid = FancyConsole.GetInput("Script to run: ").ToLower();

                    if (String.Equals(sid, "e") || String.Equals(sid, "exit"))
                    {
                        exit = true;
                        break;
                    }

                    int id = Convert.ToInt32(sid);

                    if (id == 0)
                    {
                        FancyConsole.WriteLine();
                        break;
                    }

                    if (id <= scripts.Length)
                    {
                        FancyConsole.WriteLine();
                        scriptPath = scripts[id - 1];
                        break;
                    }

                    FancyConsole.WriteLine("Invalid script id!", ConsoleColor.Red);
                    FancyConsole.WriteLine();
                }
            }

            if (!exit && String.IsNullOrWhiteSpace(scriptPath))
            {
                for (int i = 0; i < 3; i++)
                {
                    FancyConsole.WriteLine("Enter the path of the script to run...");
                    string path = FancyConsole.GetInput("Script path: ");

                    if (String.Equals(path, "e") || String.Equals(path, "exit"))
                    {
                        exit = true;
                        break;
                    }

                    if (Helpers.IsValidScriptPath(path))
                    {
                        FancyConsole.WriteLine();
                        scriptPath = path;
                        break;
                    }

                    FancyConsole.WriteLine("No script found at location: " + path, ConsoleColor.Red);
                    FancyConsole.WriteLine();
                }
            }

            if (exit)
                return;

            if (String.IsNullOrWhiteSpace(scriptPath))
            {
                GetScriptToRun();
                return;
            }

            LoadScript();
            AskToReset();
        }

        private static void LoadScript()
        {
            FancyConsole.WriteLine("Setting up script...");

            Manager.ScriptPath = scriptPath;
            script = new Script();

            ((ScriptLoaderBase)script.Options.ScriptLoader).IgnoreLuaPathGlobal = true;
            ((ScriptLoaderBase)script.Options.ScriptLoader).ModulePaths = new string[] { String.Format("{0}\\?", Manager.LibsPath), String.Format("{0}\\?.lua", Manager.LibsPath) };

            FancyConsole.WriteLine("Setting up API...");

            scriptManager.SetupApi(ref script);
            consoleManager.SetupApi(ref script);
            browserManager.SetupApi(ref script);
            youtubeManager.SetupApi(ref script);

            if (File.Exists(Path.Combine(Manager.LibsPath, "AllClass.lua")))
            {
                FancyConsole.WriteLine("Loading script 'AllClass.lua'...");
                DoLuaFile(Path.Combine(Manager.LibsPath, "AllClass.lua"));
            }

            FancyConsole.WriteLine(String.Format("{0} script '{1}'...", "Loading", Path.GetFileName(scriptPath)));
            FancyConsole.WriteLine();
            FancyConsole.WriteSeparator();
            FancyConsole.WriteLine();

            DoLuaFile(scriptPath);
            CallFunction("OnLoad");
            RunScript();
        }

        private static void RunScript()
        {
            CallFunction("OnStart");
            CallFunction("OnEnd");

            FancyConsole.WriteLine();
            FancyConsole.WriteSeparator();
            FancyConsole.WriteLine();
        }

        private static void AskToReset()
        {
            string result = FancyConsole.GetInput("Run script again (y/n): ");

            switch (result.ToLower().Trim())
            {
                case "y":
                case "yes":
                    FancyConsole.WriteLine(String.Format("Running script '{0}'...", Path.GetFileName(scriptPath)));
                    FancyConsole.WriteLine();
                    FancyConsole.WriteSeparator();
                    FancyConsole.WriteLine();
                    CallFunction("OnReset");
                    RunScript();
                    break;

                case "r":
                case "reload":
                    FancyConsole.WriteLine();
                    Unload();
                    FancyConsole.WriteLine();
                    LoadScript();
                    break;

                case "n":
                case "no":
                case "e":
                case "exit":
                case "":
                    FancyConsole.WriteLine();
                    Unload();
                    return;

                default:
                    FancyConsole.WriteLine(String.Format("Unknown command '{0}'...", result), ConsoleColor.Red);
                    FancyConsole.WriteLine();
                    break;
            }

            AskToReset();
        }

        private static void DebugMode()
        {
            FancyConsole.WriteLine("Setting up script...");

            script = new Script();
            ((ScriptLoaderBase)script.Options.ScriptLoader).IgnoreLuaPathGlobal = true;
            ((ScriptLoaderBase)script.Options.ScriptLoader).ModulePaths = new string[] { String.Format("{0}\\?", Manager.LibsPath), String.Format("{0}\\?.Lua", Manager.LibsPath) };

            FancyConsole.WriteLine("Setting up API...");

            scriptManager.SetupApi(ref script);
            consoleManager.SetupApi(ref script);
            browserManager.SetupApi(ref script);
            youtubeManager.SetupApi(ref script);

            if (File.Exists(Path.Combine(Manager.LibsPath, "AllClass.lua")))
            {
                FancyConsole.WriteLine("Loading script 'AllClass.lua'...");
                DoLuaFile(Path.Combine(Manager.LibsPath, "AllClass.lua"));
            }

            FancyConsole.WriteLine();
            FancyConsole.WriteSeparator();
            FancyConsole.WriteLine();

            bool running = true;
            bool active = true;

            while (active)
            {
                string cmd = FancyConsole.GetInput(" > ");

                switch (cmd.ToLower().Trim())
                {
                    case "r":
                    case "reload":
                        active = false;
                        running = false;
                        FancyConsole.WriteLine();
                        FancyConsole.WriteSeparator();
                        FancyConsole.WriteLine();
                        Unload();
                        FancyConsole.WriteLine();
                        DebugMode();
                        break;

                    case "e":
                    case "exit":
                        active = false;
                        break;
                }

                if (!active)
                    continue;

                Helpers.Run(() => script.DoString(cmd));
            }

            if (!running)
                return;

            FancyConsole.WriteLine();
            FancyConsole.WriteSeparator();
            FancyConsole.WriteLine();

            Unload();
        }

        private static void Unload()
        {
            FancyConsole.WriteLine("Unloading script...");
            CallFunction("OnExit");

            Manager.ScriptPath = String.Empty;
        }

        private static void DoLuaFile(string path)
        {
            Helpers.Run(() => script.DoFile(path));
        }

        private static void CallFunction(string function, params object[] args)
        {
            if (script.Globals["__" + function] != null)
                Helpers.Run(() => script.Call(script.Globals["__" + function], args));

            if (script.Globals[function] != null)
                Helpers.Run(() => script.Call(script.Globals[function], args));
        }

        private static void Close()
        {
            FancyConsole.WriteLine();
            FancyConsole.WriteSeparator(ConsoleColor.Magenta);
            FancyConsole.WriteLine("|                                                                            |", ConsoleColor.Magenta);
            FancyConsole.WriteLine("| Thank you for using my application!                                        |", ConsoleColor.Magenta);
            FancyConsole.WriteLine("|                                                                            |", ConsoleColor.Magenta);
            FancyConsole.WriteLine("| - Uses WatiN for web testing.                                              |", ConsoleColor.Magenta);
            FancyConsole.WriteLine("| - Uses MoonSharp for Lua interpreter.                                      |", ConsoleColor.Magenta);
            FancyConsole.WriteLine("|                                                                            |", ConsoleColor.Magenta);
            FancyConsole.WriteSeparator(ConsoleColor.Magenta);
            FancyConsole.WriteLine();
#if (DEBUG)
            FancyConsole.GetInput("Press enter to exit application...", ConsoleColor.Gray);
#endif
        }
    }
}