using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicMixer.musicexplorer
{
    class MusicFile
    {
        public String FilePath { get; set; }
        public String FileName { get; set; }
        public MusicFile(String filepath)
        {
            FilePath = filepath;
        }
    }

   
}
