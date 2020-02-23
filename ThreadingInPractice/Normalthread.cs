using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadingInPractice
{
    class Normalthread
    {
        bool done = false;
        public readonly object locker = new object();
        /*
         * Threads runs Simultaneously so theat in the below function ahmed printed then tawfik printed then ahmed again which mean 2 threds working 
         * BUT 
         * The CLR assigns each thread its own memory stack
         * so that local variables are kept separate. 
         * which mean if the function have local variable the value of the variable will not get ffected by the other thread 
         * 
         */
        public void TestThreadExecution()
        {
            Thread thread = new Thread(() => {

                Writesmth("tawfik");
            });

            thread.Start();
            // when we join a thread to another thread thats mean we want it finish before the calling thread continue execution 
            //thread.Join(); thats ,ean we need the current thread to sleep for some time.
            //Thread.Sleep(500);

            for (int i = 0; i < 1000; i++) Console.Write("Ahmed");
            
        }
        public void Writesmth(string stringtoprint)
        {
            for (int i = 0; i < 1000; i++)
                Console.Write(stringtoprint);

            
        }



        /*
         * When two threads simultaneously contend a lock (in this case, locker), 
         * one thread waits, or blocks, until the lock becomes available. 
         * In this case, it ensures only one thread can enter the critical section of 
         * code at a time, and “Done” will be printed just once. Code that's protected in such a manner—from indeterminacy in a multithreading context—is called thread-safe
         */
        public void TestSharedVariables()
        {


            //new Thread(PrintDone).Start();
            //PrintDone();

            //ThreadPool.QueueUserWorkItem();
        }

        public void PrintDone()
        {
            lock (locker)
            {
                if (!done)
                {
                    Console.Write("Done");
                    done = true;
                }
            }
        }


        /*
         * Forground and background threads 
         * all forground threads should be done before applications ends 
         * but 
         */




    }
}
