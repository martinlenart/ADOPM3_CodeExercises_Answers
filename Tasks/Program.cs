using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace ADOPM3_07_09
{
    class Program
    {
        private static void Main(string[] args)
        {
            var t1 = Task.Run(() => SayHello(10));
            
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine($"Bye {i}");
                Thread.Sleep(100);
            }

            (var a, var s) = t1.Result;
            Console.WriteLine($"a: {a}, s: {s}");
        }

        private static (int, string) SayHello (int NrOfHello)
        {
            var acc = 0;
            for (int i = 0; i < NrOfHello; i++)
            {
                Console.WriteLine($"Hello {i}");
                Thread.Sleep(1000);
                acc += (i+1);
            }

            return (acc, "Finished");
        }
        
    }
    //Exercise
    //1.    Remove the t1.Wait() and t2.Wait(). what hapens?
    //2.    In addition remove t1.Result and t2.Result. What happens? Explain what happens to the exception handling.
}
