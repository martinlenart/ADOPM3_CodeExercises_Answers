using System;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadSafeData
{
    class Program
    {
        //Thread Safe Datastructure
        public class ApplicationConfig
        {
            static ApplicationConfig _instance = null;
            public static ApplicationConfig Instance { 
                get 
                {
                    object _locker = new object();
                    lock (_locker)
                    {
                        if (_instance == null)
                            _instance = new ApplicationConfig();
                        return _instance;
                    }
                } 
            }

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

            private ApplicationConfig()
            {
                Owner = "Initial configuration";
                RegistrationNumber = "Initial regnummer";
            }
        }
        static void Main(string[] args)
        {
            var rnd = new Random();

            var appconfig1 = ApplicationConfig.Instance;
            Console.WriteLine(appconfig1.GetData());
            appconfig1.SetData("Hello", "Hello");

            var appconfig2 = ApplicationConfig.Instance;
            Console.WriteLine(appconfig2.GetData());

            var appconfig3 = ApplicationConfig.Instance;
            Console.WriteLine(appconfig3.GetData());

            
            var t1 = Task.Run(() =>
            {
                var localAppConfig = ApplicationConfig.Instance;
                var rnd = new Random();
                for (int i = 0; i < 1000; i++)
                {
                    //Write Data to Vehicle, "ABC 123", "Kalle Anka"
                    localAppConfig.SetData("ABC 123", "Kalle Anka");

                    //introduce some system delay
                    //Task.Delay(rnd.Next(1, 5)).Wait();

                    //Read Data from Vehicle
                    (string regNr, string owner) = localAppConfig.GetData();

                    //Verify data consistency - give error if not consistent                   
                    if ((regNr, owner) != ("ABC 123", "Kalle Anka") && (regNr, owner) != ("HKL 556", "Musse Pigg")) 
                        Console.WriteLine($"Oops from t1, Very Bad! {regNr} {owner}");
                }
                Console.WriteLine("t1 Finished");
            });

            var t2 = Task.Run(() =>
            {
                var localAppConfig = ApplicationConfig.Instance;
                var rnd = new Random();
                for (int i = 0; i < 1000; i++)
                {
                    //Write Data to Vehicle, "HKL 556", "Musse Pigg"
                    localAppConfig.SetData("HKL 556", "Musse Pigg");

                    //introduce some system delay
                    //Task.Delay(rnd.Next(1, 5)).Wait();

                    //Read Data from Vehicle
                    (string regNr, string owner) = localAppConfig.GetData();

                    //Verify data consistency - give error if not consistent                   
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
/*  Exercise
    1. Make class Vehicle Thread safe using lock(...)
    2.  - Have task t1 write 1000 times "ABC 123", "Kalle Anka" to myCar
        - Have task t2 write 1000 times "HKL 556", "Musse Pigg" to myCar
        - Verify data consistency
        - Discuss in the group what is data consistency in case of class Vehicle. Is your code living up to it?
*/
