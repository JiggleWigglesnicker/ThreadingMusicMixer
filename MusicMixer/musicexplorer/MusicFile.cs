using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage.Pickers.Provider;

namespace MusicMixer.musicexplorer
{
    class MusicFile
    {
        public String FilePath { get; set; }
        public String FileName { get; set; }
        public MusicFile(String filepath, String filename)
        {
            FilePath = filepath;
            FileName = filename;
        }
    }

   
}
