using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadingInPractice
{
    public class Semaphore
    {
        private static SemaphoreSlim _semaphore = new SemaphoreSlim(3);

        public void Enter(object id)
        {
            Console.WriteLine(id + " wants to enter");
            _semaphore.Wait();
            Console.WriteLine(id + " is in!");           // Only three threads     
            Thread.Sleep(1000 * (int)id);               // can be here at     
            Console.WriteLine(id + " is leaving");       // a time.    
            _semaphore.Release();
        }

        public void Main()
        {
            for (int i = 1; i < 6; i++)
            {
               new Thread(Enter).Start(i);
            }
        }
    }
}
