using MusicMixer.musicplayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices.ComTypes;

namespace MusicMixer.musicexplorer
{
    class MusicExplorer
    {
        private String path;
        //BIND Track to buttons in view
        private HashSet<MusicFile> musicList = new HashSet<MusicFile>();

        public MusicExplorer()
        {
            path = Path.Combine(Environment.CurrentDirectory, @"MusicFolder");
            CreateMusicFolder();
        }

        public bool CheckIfMusicFolderExist()
        {
            return Directory.Exists(path);
        }

        public void CreateMusicFolder()
        {
            if (!CheckIfMusicFolderExist())
            {
             //   Directory.CreateDirectory(path);
            }
            else
            {
                Console.WriteLine("Musicfolder already exist");
            }

        }

        // moet MULTITHREADED
        public void FindNewMusic()
        {
            foreach (String musictrack in Directory.GetFiles(path))
            {
                MusicFile musicFile = new MusicFile(musictrack);
                musicList.Add(musicFile);

            }
        }

    }
}
