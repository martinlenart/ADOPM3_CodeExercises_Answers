using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;


namespace Async1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            const int NrInts = 1_000_000_000;
            var timer = new Stopwatch();
            Console.WriteLine($"Start {NrInts:N0} additions");

            timer.Start();
            var sum = AddEvenInts(NrInts);
            sum += AddOddInts(NrInts);

            Console.WriteLine($"Total sum: {sum:N0}");
            File.WriteAllText(fname("AdditionSync.txt"), $"Total sum: {sum:N0}");
            timer.Stop();

            Console.WriteLine($"\nElapsed time in ms: {timer.ElapsedMilliseconds}");

            //Asyncronous but sequential execution
            Console.WriteLine($"\nStart async sequential {NrInts:N0} additions");
            timer.Restart();

            sum = await AddEvenIntsAsync(NrInts);
            sum += await AddOddIntsAsync(NrInts);

            Console.WriteLine($"Total sum: {sum:N0}");
            var tw1 = File.WriteAllTextAsync(fname("AdditionAsync1.txt"), $"Total sum: {sum:N0}");

            timer.Stop();

            Console.WriteLine($"\nElapsed time in ms: {timer.ElapsedMilliseconds}");

            //Asyncronous and parallel execution
            Console.WriteLine($"\nStart async parallel {NrInts:N0} additions");
            timer.Restart();

            var t1 = AddEvenIntsAsync(NrInts);
            var t2 = AddOddIntsAsync(NrInts);

            sum = await t1;
            sum += await t1;
 
            Console.WriteLine($"Total sum: {sum:N0}");
            var tw2 = File.WriteAllTextAsync(fname("AdditionAsync2.txt"), $"Total sum: {sum:N0}");
            
            timer.Stop();

            Console.WriteLine($"\nElapsed time in ms: {timer.ElapsedMilliseconds}");

            Task.WaitAll(tw1, tw2);
            //await tw1;
            //await tw2;
        }

        public static Task<long> AddEvenIntsAsync(int NrOfInts)
        {
            return Task.Run(() => AddEvenInts(NrOfInts));
        }

        public static Task<long> AddOddIntsAsync(int NrOfInts)
        {
            return Task.Run(() => AddOddInts(NrOfInts));
        }


        public static long AddEvenInts(int NrOfInts)
        {
            long sum = 0;
            for (int i = 0; i < NrOfInts; i++)
            {
                if (i % 2 == 0)
                    sum += i;
            }
            return sum;
        }
        public static long AddOddInts(int NrOfInts)
        {
            long sum = 0;
            for (int i = 0; i < NrOfInts; i++)
            {
                if (i % 2 != 0)
                    sum += i;
            }
            return sum;
        }


        static string fname(string name)
        {
            var documentPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            documentPath = Path.Combine(documentPath, "AOOP2", "Examples");
            if (!Directory.Exists(documentPath)) Directory.CreateDirectory(documentPath);
            return Path.Combine(documentPath, name);
        }
    }
}
