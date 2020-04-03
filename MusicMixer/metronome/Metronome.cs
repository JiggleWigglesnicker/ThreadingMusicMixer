using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace MusicMixer.metronome
{
    class Metronome
    {

        private int bpm;
        private int ticks;

        public Metronome(int bpm)
        {
            bpm = this.bpm;
        }

        private double BpmToSeconds()
        {
            return TimeSpan.FromSeconds(60 / bpm).TotalMilliseconds;
        }

        private void Beep()
        {
            while (true)
            {
                Console.Beep(4000, 100);
                Thread.Sleep(Convert.ToInt32(BpmToSeconds()));
            }
        }
    }
}
