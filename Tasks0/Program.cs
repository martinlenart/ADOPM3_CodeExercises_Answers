using System;
using System.Diagnostics;

namespace Task0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string Message = "What a wounderful day!";
            var watch = new Stopwatch();
            watch.Start();

            var t1 = Task.Run(() =>
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine($"{Message}{i} from t1");
                    Task.Delay(2000).Wait();
                }
            });
            //t1.Wait();

            var t2 = Task.Run(() =>
            {
                for (int i = 0; i < 10; i++)
                {

                    Console.WriteLine($"{Message}{i} from t2");
                    Task.Delay(1000).Wait();
                }
            });
            //t2.Wait();

            var t3 = Task.Run(() =>
            {
                for (int i = 0; i < 15; i++)
                {
                    Console.WriteLine($"{Message}{i} from t3");
                    Task.Delay(500).Wait(); ;
                }
            });
            //t3.Wait();

            Task.WaitAll(t1, t2, t3);

            watch.Stop();
            Console.WriteLine($"Main terminated. Execution time: {watch.ElapsedMilliseconds}ms");
        }
    }
}
// Exercises
//1. Create and start a Task t1 that loops 5 times and in each loop prints out "Hello{i} from Thread1" and sleeps 2 second
//2. Create and start a Task t2 that loops 10 times and in each loop prints out "Hello{i} from Thread2" and sleeps 1 second
//3. Create and start a Task t3 that loops 15 times and in each loop prints out "Hello{i} from Thread3" and sleeps 0,5 second
//4. Change the order of execution using t1.Wait() so that t2 and t3 starts after t1 has completed execution
//5. Experiment by changig the t1/t2/t3.Wait() and see what happends
