using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static AutoResetEvent auto = new AutoResetEvent(false);
        public static Mutex m;//线程互斥
        private static int Count = 9;
        static void Main(string[] args)
        {
            m = new Mutex();
            Thread t1 = new Thread(setValue);
            Thread t2 = new Thread(getValue);
            t1.Start();
            t2.Start();
        }
        public static void setValue()
        {
            for (int i = 0; i < Count; i++)
            {
                m.WaitOne();//阻塞线程
                Console.WriteLine("a:"+ Thread.CurrentThread.ManagedThreadId);
                m.ReleaseMutex();//释放Mutex
            }
        }
        public static void getValue()
        {
            for (int i = 0; i < Count; i++)
            {
                m.WaitOne();
                Console.WriteLine("b:" + Thread.CurrentThread.ManagedThreadId);
                m.ReleaseMutex();
            }
        }
        public static void getValue1()
        {
            for (int i = 0; i < Count; i++)
            {
                m.WaitOne();
                Console.WriteLine("c" + Thread.CurrentThread.ManagedThreadId);
                m.ReleaseMutex();
            }
        }
    }
}
