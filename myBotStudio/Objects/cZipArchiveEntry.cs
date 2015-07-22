using MoonSharp.Interpreter;
using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myBotStudio.Objects
{
    [MoonSharpUserData]
    public class cZipArchiveEntry
    {
        private ZipArchiveEntry zip;

        public cZipArchiveEntry(ZipArchiveEntry obj)
        {
            zip = obj;
        }

        public void Delete()
        {
            zip.Delete();
        }

        public void Open()
        {
            zip.Open();
        }

        public cZipArchive Archive
        {
            get { return new cZipArchive(zip.Archive); }
        }

        public long CompressedLength
        {
            get { return zip.CompressedLength; }
        }

        public string FullName
        {
            get { return zip.FullName; }
        }

        public long Length
        {
            get { return zip.Length; }
        }

        public string Name
        {
            get { return zip.Name; }
        }
    }
}
