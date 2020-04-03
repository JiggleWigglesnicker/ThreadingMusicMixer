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
