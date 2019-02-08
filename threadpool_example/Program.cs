using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace threadpool_example
{
    class Program
    {
        static int x = 0;
        static int y = 0;
        static int z = 0;
        static int w, p;
        const int loop = 50;

        static Object key = "A";
        static Object key2 = "A";

        static void Main(string[] args)
        {
            //ThreadPool.QueueUserWorkItem(ThreadingZ);
            for (int timer = 0; timer < loop; timer++)
            {
                ThreadPool.QueueUserWorkItem(ThreadingX, "StateMessageX");
                ThreadPool.QueueUserWorkItem(ThreadingY, "StateMessageY");
            }
            Console.ReadKey();
        }

        public static void ThreadingX(Object StateInfo)
        {
            lock (key)
            {
                ThreadPool.GetAvailableThreads(out w, out p);
                Console.WriteLine("Worker Thread = " + w + " CompletionPort Thred = " + p);

                var StringSomething = (String)StateInfo;
                if (x != loop - 1) Console.WriteLine("Current Thread ID " + Thread.CurrentThread.ManagedThreadId + " || X" + x++ + " || " + StringSomething);
                else Console.WriteLine("Current Thread ID " + Thread.CurrentThread.ManagedThreadId + " || X LOOPA ULAŞTI, X=" + x + " || " + StringSomething);
            }
        }

        public static void ThreadingY(Object StateInfo)
        {
            lock (key)
            {
                ThreadPool.GetAvailableThreads(out w, out p);
                Console.WriteLine("Worker Thread = " + w + " CompletionPort Thred = " + p);

                var StringSomething = (String)StateInfo;
                if (y != loop - 1) Console.WriteLine("Current Thread ID " + Thread.CurrentThread.ManagedThreadId + " || Y" + y++ + " || " + StringSomething);
                else Console.WriteLine("Current Thread ID " + Thread.CurrentThread.ManagedThreadId + " || Y LOOPA ULAŞTI, Y=" + y + " || " + StringSomething);
            }
        }

        public static void ThreadingZ(Object StateInfo)
        {

        }
    }

}
