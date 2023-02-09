using System;
using System.Threading;

namespace DispatchQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            DispatchQueue myQueue = new DispatchQueue();

            DispatchQueue.main.Async((_) => {
                for (int i = 0; i < 100; i++)
                {
                    Console.WriteLine($"From Main Queue {i}");
                    Thread.Sleep(1000);
                }
            });

            myQueue.Async((_) => {
                for (int i = 0; i < 100; i++)
                {
                    Console.WriteLine($"From My Queue {i}");
                    Thread.Sleep(500);
                }
            });

            Console.ReadKey();
        }
    }
}
