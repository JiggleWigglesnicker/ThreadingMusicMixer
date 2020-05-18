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
        /**
         * Plays the beep sound
         */
        public void Beep(double bpm, MainPage main)
        {
            //setts the bpmstop boolean to false
            main.SetBpmStop();
            //converts the given bpm to miliseconds for the intervals
            int intBpm = Convert.ToInt32(BpmToMiliSeconds(bpm));
            //sets the beeps sound
            Uri src = new Uri("ms-appx:///Assets/beep.wav");
            //keep looping till break
            while (true)
            {
                Windows.Media.Playback.BackgroundMediaPlayer.Current.SetUriSource(src);
                Thread.Sleep(intBpm);

                if (main.bpmStop) //If true break loop
                {
                    break;
                }
            }
        }
    }
}
