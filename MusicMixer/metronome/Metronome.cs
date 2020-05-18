using System;
using System.Threading;

namespace MusicMixer.metronome
{
    class Metronome
    {

        private double bpm;

        /**
         * Converts the specified bpm to time between beats in miliseconds
         * @Returns float
         */
        private float BpmToMiliSeconds(double bpm)
        {
            //Seconds in a minute
            float minute = 60;
            //Converts the double to float
            float bpm1 = Convert.ToSingle(bpm);
            //Returns time between beats in miliseconds
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
