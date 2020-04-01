using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicMixer.musiclistitems
{
    class MusicLibrary
    {
        private String nameLibrary;

        private MusicList musicList;

        public MusicLibrary()
        {

        }

        public String getNameLibrary()
        {
            return nameLibrary;
        }

        public void setNameLibrary(String namelib)
        {
            nameLibrary = namelib;
        }

        public int countTracks()
        {
            return musicList.getNameList().Length;
        }

        //TODO: needs to count album
        public int CountAlbums() {
            return 0;
        }

    }
}
