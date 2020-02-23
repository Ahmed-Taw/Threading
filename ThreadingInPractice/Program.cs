using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadingInPractice
{
    class Program
    {
        static void Main(string[] args)
        {

            //runasync();
            //Console.WriteLine(String.Format("main thread {0}", Thread.CurrentThread.ManagedThreadId));
            //Normalthread normalthread = new Normalthread();
            //normalthread.TestThreadExecution();

            //ThreadLock lockthread = new ThreadLock();
            //lockthread.DeadLock();

            //Mutexs mutexs = new Mutexs();
            //mutexs.MutexTest();

            Semaphore semaphore = new Semaphore();
            semaphore.Main();
            //ThreadPool.QueueUserWorkItem(Go);
            Console.ReadLine();
        }

        static void Go(object data)
        {
            Console.WriteLine("Gp !!");
        }

        //public static async void runasync()
        //{

        //    var testth = Task.Run(() =>
        //    {
        //        var test = getlist();
        //        Console.WriteLine(String.Format("thread1 "+ Thread.CurrentThread.ManagedThreadId + ""));
        //    });

        //    testth.ContinueWith(o =>
        //    {
        //        Console.WriteLine(String.Format("continution thread {0}", Thread.CurrentThread.ManagedThreadId));

        //    });

        //}
        //public static int[] getlist()
        //{
        //    return new int[3];

        //}
    }
}
