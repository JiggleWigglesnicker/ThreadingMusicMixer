using System;
using System.Threading;

namespace MusicMixer.metronome
{
    class Metronome
    {
        /// <summary>
        /// Converts the specified bpm to time between beats in miliseconds
        /// </summary>
        /// <param name="bpm"></param>
        /// <returns></returns>
        private float BpmToMiliSeconds(double bpm)
        {
            float minute = 60; //Seconds in a minute
            float bpm1 = Convert.ToSingle(bpm); //Converts the double to float
            return ((minute / bpm1) * 1000); //Returns time between beats in miliseconds
        }

        /// <summary>
        /// Plays the beep sound
        /// </summary>
        /// <param name="bpm"></param>
        /// <param name="main"></param>
        public void Beep(double bpm, MainPage main)
        {
            main.SetBpmStop(); //sets the bpmstop boolean to false
            int intBpm = Convert.ToInt32(BpmToMiliSeconds(bpm)); //converts the given bpm to miliseconds for the intervals
            Uri src = new Uri("ms-appx:///Assets/beep.wav"); //sets the beeps sound
            while (true) //keep looping till break
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
