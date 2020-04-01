using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicMixer.musiclistitems
{
    class MusicAlbum : MusicList
    {
        private String bandName;

        private String artistName;

        public MusicAlbum()
        {

        }

        public String getBandName()
        {
            return bandName;
        }

        public void setBandName(String bandName)
        {
            this.bandName = bandName;
        }


        public String getArtistName()
        {
            return artistName;
        }

        public void setArtistName(String artistName)
        {
            this.artistName = artistName;
        }
    }
}
