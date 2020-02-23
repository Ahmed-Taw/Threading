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

            //Semaphore semaphore = new Semaphore();
            //semaphore.Main();

            //Parallelism parallelism = new Parallelism();
            //parallelism.Invoke();
            //ConcurrencyStructures concurrencyStructures = new ConcurrencyStructures();
            //concurrencyStructures.Main();

            //ThreadPool.QueueUserWorkItem(Go);
            //Tasks tasks = new Tasks();
            ////tasks.StartTasks();
            ////tasks.StartTasksWithCancelationToken();
            //tasks.ContinueWithExample();
            //Console.WriteLine($"thread main {Thread.CurrentThread.ManagedThreadId}");
            ////Thread.Sleep(10);

            SharedResources sharedResources = new SharedResources();
            for (int i = 0; i < 10; i++)
            {
                Console.ReadLine();
                sharedResources.PlayAHealthGame();

            }
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
