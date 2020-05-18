using MusicMixer.musicplayer;
using System;
using System.Collections.Generic;
using System.IO;


namespace MusicMixer.musicexplorer
{
    class MusicExplorer
    {

        private HashSet<MusicFile> musicList = new HashSet<MusicFile>();

        public MusicExplorer()
        {
            CreateMusicFolder();
        }

        public bool CheckIfMusicFolderExist()
        {
            return Directory.Exists("C:\\Users\\Prime Knight\\source\repos\\ThreadingMusicMixer\\MusicMixer\\MusicFolder");
        }

        public void CreateMusicFolder()
        {
            if (!CheckIfMusicFolderExist())
            {
                Directory.CreateDirectory("C:\\Users\\Prime Knight\\source\repos\\ThreadingMusicMixer\\MusicMixer\\MusicFolder");
            }
            else
            {
                Console.WriteLine("Musicfolder already exist");
            }

        }

        public void FindNewMusic()
        {
            foreach (File musictrack in  )
            {

            }
        }

    }
}
