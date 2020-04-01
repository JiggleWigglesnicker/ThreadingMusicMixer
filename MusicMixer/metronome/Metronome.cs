using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicMixer.metronome
{
    class Metronome
    {

        private double speed;
        private int ticks;

        public Metronome()
        {

        }

        public void setTicks(int ticks)
        {
            this.ticks = ticks;
        }

        public int getTicks()
        {
            return ticks;
        }

        public void setSpeed(double speed)
        {
            this.speed = speed;
        }

        public double getSpeed()
        {
            return speed;
        }

        public void start()
        {

        }

        public void stop()
        {
        }
    }
}
