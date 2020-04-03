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


        public Metronome()
        {
        }

        private float BpmToMiliSeconds(double bpm)
        {
            float minute = 60;
            float bpm1 = Convert.ToSingle(bpm);
            return ((minute / bpm1) * 1000);
        }

        public void Beep(double bpm, MainPage main)
        {
            main.setBpmStop();
            int intBpm = Convert.ToInt32(BpmToMiliSeconds(bpm));
            Uri src = new Uri("ms-appx:///Assets/beep.wav");
            while (true)
            {
                Windows.Media.Playback.BackgroundMediaPlayer.Current.SetUriSource(src);
                Thread.Sleep(intBpm);

                if (main.bpmStop) // what im waiting for...
                    break;
            }
        }
    }
}
