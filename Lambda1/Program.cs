using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        public enum Vehicles { Unknown, MC, Car, Scooter, Snowmobile, ElectricBike, Last};
        static void Main(string[] args)
        {
            var rnd = new Random();
            List<Vehicles> vehicles = new List<Vehicles>();
            for (int i = 0; i < 100; i++)
            {
                var v = (Vehicles) rnd.Next((int) Vehicles.Unknown+1, (int) Vehicles.Last);
                vehicles.Add(v);
            }

            //Exercise 1 Alternativ 1
            Console.WriteLine("Alternative1");
            for (Vehicles _vehicle = Vehicles.Unknown + 1; _vehicle < Vehicles.Last; _vehicle++)
            {
                int _count = 0;
                vehicles.ForEach(v => { if (v == _vehicle) _count++; });
                Console.WriteLine($"{_vehicle,20}: {_count}");
            }


            //Alternativ 2
            Console.WriteLine("\nAlternative2");
            int _count1 = 0;
            Dictionary<Vehicles, Action<Vehicles>> actions = new Dictionary<Vehicles, Action<Vehicles>>();
            for (Vehicles _vehicle = Vehicles.Unknown + 1; _vehicle < Vehicles.Last; _vehicle++)
            {
                var _localSearch = _vehicle; 
                actions[_vehicle] = (v => { if (v == _localSearch) _count1++; });
            }

            for (Vehicles _vehicle = Vehicles.Unknown + 1; _vehicle < Vehicles.Last; _vehicle++)
            {
                _count1 = 0;
                vehicles.ForEach(actions[_vehicle]);
                Console.WriteLine($"{_vehicle,20}: {_count1}");
            }
        }
    }
}
//Exercises:
//1.  Loop over all the Vehicle types in enum Vehicles and in the loop use vehicles.ForEach(),
//    Lambda and a captured variable to count and present number of vehicles of each type in vehicles.
//    - example MC: 25 / Car: 50 / ...