using System;
using System.Threading;

namespace ThreadSafeData
{
    class Program
    {
        //Thread Safe Datastructure
        public class TSafeData
        {
            object _locker = new object();
            int iSafeResult1 = 0;
            int iSafeResult2 = 0;

            public void SetData(int data1, int data2)
            {
                lock (_locker)
                {
                    iSafeResult1 = data1;
                    iSafeResult2 = data2;
                }
            }
            public void GetData(out int data1, out int data2)
            {
                lock (_locker)
                {
                    data1 = iSafeResult1;
                    data2 = iSafeResult2;
                }
            }
        }
        static void Main(string[] args)
        {
            var mySafeData = new TSafeData();

            new Thread((arg) =>
            {
                var localSafeData = (TSafeData)arg;

                var rnd = new Random();
                for (int i = 0; i < 500; i++)
                {
                    //Write data in a threadsafe manner
                    localSafeData.SetData(1111, 1111);
                    Console.Write("1");

                    //Just to verify data consistency
                    Thread.Sleep(rnd.Next(1, 50));
                    localSafeData.GetData(out int i1, out int i2);

                    if (i1 != i2)
                        Console.WriteLine("Safe mismatch");
                }             
            }).Start(mySafeData);

            new Thread((arg) =>
            {
                var localSafeData = (TSafeData)arg;

                var rnd = new Random();
                for (int i = 0; i < 500; i++)
                {
                    //Write data in a threadsafe manner
                    localSafeData.SetData(2222, 2222);
                    Console.Write("2");

                    //Just to verify data consistency
                    Thread.Sleep(rnd.Next(1, 50));
                    localSafeData.GetData(out int i1, out int i2);

                    if (i1 != i2)
                        Console.WriteLine("Safe mismatch");
                }
            }).Start(mySafeData);
        }
    }
}
