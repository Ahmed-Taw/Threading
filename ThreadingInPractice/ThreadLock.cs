using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadingInPractice
{
    class ThreadLock
    {

        bool done = false;
        public readonly object locker = new object();

        /*
 * Locking constructs 
These limit the number of threads that can perform some activity or execute 
a section of code at a time. 
Exclusive locking constructs are most common—these allow just one thread in at a time, 
and allow competing threads to access common data without interfering with each other. 
The standard exclusive locking constructs are 
lock (Monitor.Enter/Monitor.Exit), 
Mutex, 
and SpinLock. 
The nonexclusive locking constructs are 
Semaphore, 
SemaphoreSlim, 
and the reader/writer locks. 
 */

        /*
         * lock has 2 types 
         *  1- only one thread can access te code inside the lock 
         *      - Lock
         *      -Monitor.Enter Mointor.Exit
         *      -Mutex
         *  2- specific number of threads could access the code and after we reach the maximum number no threads could access the code
         *      - Semaphore 
         *      - semaphoreslim
         */



        public void TestSharedVariables()
        {


            new Thread(PrintDone).Start();
            PrintDone();

           
            //ThreadPool.QueueUserWorkItem();
        }

        public void PrintDone()
        {
            Monitor.Enter(locker);
            try
            {
                if (!done)
                {
                    done = true;
                    Console.Write("Done");
                }
            }
            finally
            {
                //Calling Monitor.Exit without first calling Monitor.Enter on the same object throws an exception. 
                Monitor.Exit(locker);

            }
        }

        /*
         Nested Locking 
A thread can repeatedly lock the same object in a nested (reentrant) fashion:

            the lock released with the most outer lock released 

         */

        public void NestedLock()
        {
            lock (locker)
            {

                this.TestSharedVariables();
            }
        }



        /*
         * Deadlocks 
A deadlock happens when two threads each wait for a resource held by the other, so neither can proceed
         */
        public void DeadLock()
        {
            object locker1 = new object(); object locker2 = new object();

            new Thread(() =>
            {
                lock (locker1)
                {
                    Thread.Sleep(1000); lock (locker2) ;      // Deadlock               
                }
            }).Start();

            lock (locker2)
            {
                lock (locker1) ;
                Thread.Sleep(1000);                           // Deadlock 
            }

            }




    }

    
}
