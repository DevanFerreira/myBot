using MoonSharp.Interpreter;
using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myBot.Objects
{
    [MoonSharpUserData]
    public class cZipArchive
    {
        private ZipArchive zip;

        public cZipArchive(ZipArchive obj)
        {
            zip = obj;
        }

        public cZipArchiveEntry[] Entries
        {
            get
            {
                IReadOnlyCollection<ZipArchiveEntry> col = zip.Entries;
                List<cZipArchiveEntry> ncol = new List<cZipArchiveEntry>();

                for (int i = 0; i < col.Count; i++)
                    ncol.Add(new cZipArchiveEntry(col.ElementAt(i)));

                return ncol.ToArray();
            }
        }

        public ZipArchiveMode Mode
        {
            get { return zip.Mode; }
        }

        public cZipArchiveEntry CreateEntry(string name, DynValue compression)
        {
            if (compression.IsNotNil())
                return new cZipArchiveEntry(zip.CreateEntry(name, compression.ToObject<CompressionLevel>()));
            else
                return new cZipArchiveEntry(zip.CreateEntry(name));
        }

        public cZipArchiveEntry GetEntry(string name)
        {
            return new cZipArchiveEntry(zip.GetEntry(name));
        }
    }
}
