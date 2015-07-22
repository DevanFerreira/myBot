using MoonSharp.Interpreter;
using MoonSharp.Interpreter.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeExtractor;

namespace myBotStudio.Managers
{
    public enum cAdaptiveType
    {
        None,
        Audio,
        Video,
    }

    public enum cAudioType
    {
        Aac,
        Mp3,
        Unknown,
        Vorbis,
    }

    public enum cVideoType
    {
        Flash,
        Mobile,
        Mp4,
        Unknown,
        WebM,
    }

    [MoonSharpUserData]
    public class YoutubeManager
    {
        [MoonSharpVisible(false)]
        public void SetupApi(ref Script script)
        {
            script.Globals["Youtube"] = this;
        }

        public cVideoInfo[] GetDownloadUrls(string url, DynValue _decrypt)
        {
            IEnumerable<VideoInfo> col = DownloadUrlResolver.GetDownloadUrls(url, (_decrypt.IsNotNil()) ? _decrypt.Boolean : true);
            List<cVideoInfo> ncol = new List<cVideoInfo>();

            for (int i = 0; i < col.Count(); i++)
                ncol.Add(new cVideoInfo(col.ElementAt(i)));

            return ncol.ToArray();
        }

        public string NormalizeUrl(string url, ref bool successful)
        {
            string result = String.Empty;
            successful = DownloadUrlResolver.TryNormalizeYoutubeUrl(url, out result);
            return result;
        }
    }

    public class cVideoInfo
    {
        [MoonSharpVisible(false)]
        public VideoInfo obj;

        public cVideoInfo(VideoInfo info)
        {
            obj = info;
        }

        public cAdaptiveType AdaptiveType
        {
            get
            {
                switch (obj.AdaptiveType)
                {
                    case YoutubeExtractor.AdaptiveType.Audio:
                        return cAdaptiveType.Audio;

                    case YoutubeExtractor.AdaptiveType.Video:
                        return cAdaptiveType.Video;

                    default:
                    case YoutubeExtractor.AdaptiveType.None:
                        return cAdaptiveType.None;
                }
            }
        }

        public int AudioBitrate
        {
            get { return obj.AudioBitrate; }
        }

        public string AudioExtension
        {
            get { return obj.AudioExtension; }
        }

        public cAudioType AudioType
        {
            get
            {
                switch (obj.AudioType)
                {
                    case YoutubeExtractor.AudioType.Aac:
                        return cAudioType.Aac;

                    case YoutubeExtractor.AudioType.Mp3:
                        return cAudioType.Mp3;

                    case YoutubeExtractor.AudioType.Vorbis:
                        return cAudioType.Vorbis;

                    default:
                    case YoutubeExtractor.AudioType.Unknown:
                        return cAudioType.Unknown;
                }
            }
        }

        public bool CanExtractAudio
        {
            get { return obj.CanExtractAudio; }
        }

        public string DownloadUrl
        {
            get { return obj.DownloadUrl; }
        }

        public int FormatCode
        {
            get { return obj.FormatCode; }
        }

        public bool Is3D
        {
            get { return obj.Is3D; }
        }

        public bool RequiresDecryption
        {
            get { return obj.RequiresDecryption; }
        }

        public int Resolution
        {
            get { return obj.Resolution; }
        }

        public string Title
        {
            get { return obj.Title; }
        }

        public string VideoExtension
        {
            get { return obj.VideoExtension; }
        }

        public cVideoType VideoType
        {
            get
            {
                switch (obj.VideoType)
                {
                    case YoutubeExtractor.VideoType.Flash:
                        return cVideoType.Flash;

                    case YoutubeExtractor.VideoType.Mobile:
                        return cVideoType.Mobile;

                    case YoutubeExtractor.VideoType.Mp4:
                        return cVideoType.Mp4;

                    case YoutubeExtractor.VideoType.WebM:
                        return cVideoType.WebM;

                    default:
                    case YoutubeExtractor.VideoType.Unknown:
                        return cVideoType.Unknown;
                }
            }
        }

        public void DownloadVideo(string filepath, DynValue callback)
        {
            Decrypt();
            VideoDownloader downloader = new VideoDownloader(obj, filepath);

            if (callback.IsNotNil())
                downloader.DownloadFinished += (sender, args) => Program.Call(callback, obj);

            downloader.Execute();
        }

        public void DownloadAudio(string filepath, DynValue callback)
        {
            Decrypt();
            AudioDownloader downloader = new AudioDownloader(obj, filepath);
            
            if (callback.IsNotNil())
                downloader.DownloadFinished += (sender, args) => Program.Call(callback, obj);

            downloader.Execute();
        }

        public void Decrypt()
        {
            if (obj.RequiresDecryption)
                DownloadUrlResolver.DecryptDownloadUrl(obj);
        }
    }
}
