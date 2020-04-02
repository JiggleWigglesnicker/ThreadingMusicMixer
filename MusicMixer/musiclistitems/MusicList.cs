using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace MusicMixer.musiclistitems
{
    abstract class MusicList
    {
        private String nameList;
        private String folderPath;
        private HashSet<MusicTrack> musicStorage = new HashSet<MusicTrack>();

        public MusicList()
        {

        }

        public void CreateSelectFolder()
        {
            // Specify the directory you want to manipulate.
            string path = @"D:\0Icons\Downloads\music";

            try
            {
                // Determine whether the directory exists.
                if (Directory.Exists(path))
                {
                    Console.WriteLine("That path exists already.");
                    return;
                }
                else {
                    DirectoryInfo di = Directory.CreateDirectory(path);
                    Console.WriteLine("The directory was created successfully at {0}.", Directory.GetCreationTime(path));
                }

              
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
        }

        public String getNameList()
        {
            return nameList;
        }

        public void setNameList(String name)
        {
            nameList = name;
        }


        public String getFolderPath()
        {
            return folderPath;
        }

        public void setFolderPath(String path)
        {
            folderPath = path;
        }

        public void addmusic(MusicTrack musictrack)
        {
            musicStorage.Add(musictrack);
        }

        //TODO: needs to be changed to get track
        public MusicTrack getMusicTrack(String musictrack)
        {
            return null;
        }


    }
}
