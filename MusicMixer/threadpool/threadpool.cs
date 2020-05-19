using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicMixer.threadpool
{
    class threadpool
    {
        private static void
            TaskCallBack(Object ThreadNumber)
        {
            string ThreadName = "Thread " +
                ThreadNumber.ToString();
            for (int i = 1; i < 10; i++)
                Console.WriteLine(ThreadName
                    + ": " + i.ToString());
            Console.WriteLine(ThreadName
                + "Finished...");
        }
    }
}
