using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace MusicMixer.metronome
{
    class Metronome
    {

        private double bpm;
        private bool stop;


        public Metronome()
        {
            stop = false;
        }

        private float BpmToMiliSeconds(double bpm)
        {
            float minute = 60;
            float bpm1 = Convert.ToSingle(bpm);
            return ((minute / bpm1) * 1000);
        }

        public void setStop(bool stopper)
        {
            this.stop = stopper;
        }

        public void Beep(double bpm)
        {
            int intBpm = Convert.ToInt32(BpmToMiliSeconds(bpm));
            Uri src = new Uri("ms-appx:///Assets/beep.wav");
            while (true)
            {
                Windows.Media.Playback.BackgroundMediaPlayer.Current.SetUriSource(src);
                Thread.Sleep(intBpm);

                if (this.stop) // what im waiting for...
                    break;
            }
        }
    }
}
