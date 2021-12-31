using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Occult.Util
{
    class Timer
    {
        private float DestinTime;
        private double currentTime;
        public Timer(float Timer)
        {

        }

        public bool Tick(double timeInterval)
        {
            if (currentTime >= DestinTime) return true;
            currentTime += timeInterval;
            return false;
        }

        public bool isOverTime()
        {
            return currentTime >= DestinTime;
        }

        public void restartTimer()
        {
            currentTime = 0;
        }
    }
}
