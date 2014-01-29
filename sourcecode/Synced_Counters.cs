using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace SyncedCounters
{
    class Count
    {
        private int CounterNr;
        static int cVal = 0;
        private static Semaphore sem;

        public Count(int i)
        {
            sem = new Semaphore(1, 1);
            CounterNr = i;
            Console.WriteLine("+++ Thread {0} started.", CounterNr);
        }

        public void Increment()
        {
            while (true)
            {
                sem.WaitOne();
                int buf = cVal;
                if (buf == 20)
                {
                    Console.WriteLine("+++ Thread {0} is finished.", CounterNr);
                    sem.Release();
                    break;
                }

                cVal = buf + 1;
                Console.WriteLine("--- Thread {0} was here. New: {1}", CounterNr, cVal);
                sem.Release();

                Random r = new Random();
                Thread.Sleep(r.Next(400));
            }
        }

    }

    class Program
    {

        static void Main(string[] args)
        {
            Count c1 = new Count(1);
            Count c2 = new Count(2);
            Count c3 = new Count(3);
            Count c4 = new Count(4);

            Thread t1 = new Thread(c1.Increment);
            Thread t2 = new Thread(c2.Increment);
            Thread t3 = new Thread(c3.Increment);
            Thread t4 = new Thread(c4.Increment);

            t1.Start();
            t2.Start();
            t3.Start();
            t4.Start();

            Console.ReadLine();
        }
    }
}
