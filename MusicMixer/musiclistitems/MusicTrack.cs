using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicMixer.musiclistitems
{
    class MusicTrack
    {


        private String musicTrackPath;

        private String musicTrackName;

        private int trackLength;

        public MusicTrack()
        {

        }

        public String getMusicTrackPath()
        {
            return musicTrackPath;
        }

        public void setMusicTrackPath(String path)
        {
            musicTrackPath = path;
        }

        public String getMusicTrackName()
        {
            return musicTrackName;
        }

        public void setMusicTrackName(String name) {
            musicTrackName = name;
        }
    }
}
