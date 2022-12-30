using System;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadSafeData
{
    class Program
    {
        //Thread Safe Datastructure
        public class Vehicle
        {
            object _locker = new object();
            string RegistrationNumber;
            string Owner;

            public void SetData(string regNr, string owner)
            {
                lock (_locker)
                {
                    RegistrationNumber = regNr;
                    Owner = owner;
                }
            }
            public (string regNr, string owner) GetData()
            {
                lock (_locker) { return (RegistrationNumber, Owner); }
            }
        }
        static void Main(string[] args)
        {
            var myCar = new Vehicle();
            var rnd = new Random();

            var t1 = Task.Run(() =>
            {
                var rnd = new Random();
                for (int i = 0; i < 1000; i++)
                {
                    myCar.SetData("ABC 123", "Kalle Anka");

                    //introduce some system delay
                    //Task.Delay(rnd.Next(1, 5));//.Wait();

                    (string regNr, string owner) = myCar.GetData();
                    
                    if ((regNr, owner) != ("ABC 123", "Kalle Anka") && (regNr, owner) != ("HKL 556", "Musse Pigg")) 
                        Console.WriteLine($"Oops from t1, Very Bad! {regNr} {owner}");
                }
                Console.WriteLine("t1 Finished");
            });

            var t2 = Task.Run(() =>
            {
                var rnd = new Random();
                for (int i = 0; i < 1000; i++)
                {
                    myCar.SetData("HKL 556", "Musse Pigg");

                    //introduce some system delay
                    //Task.Delay(rnd.Next(1, 5));//.Wait();

                    (string regNr, string owner) = myCar.GetData();

                    if ((regNr, owner) != ("ABC 123", "Kalle Anka") && (regNr, owner) != ("HKL 556", "Musse Pigg"))
                        Console.WriteLine($"Oops from t2, Very Bad! {regNr} {owner}");
                }
                Console.WriteLine("t2 Finished");
            });

            Task.WaitAll(t1, t2);
            Console.WriteLine("All Finished");
        }
    }
}
