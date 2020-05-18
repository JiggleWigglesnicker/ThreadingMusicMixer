using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicMixer.musicexplorer
{
    class MusicExplorer
    {
        public MusicExplorer() {
        
        }

        public bool CheckIfMusicFolderExist() {
            return Directory.Exists("C:\\Users\\Prime Knight\\source\repos\\ThreadingMusicMixer\\MusicMixer\\MusicFolder");
        }
    }
}
