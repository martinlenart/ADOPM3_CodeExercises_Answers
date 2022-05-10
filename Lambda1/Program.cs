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

            //Alternativ 1
            for (Vehicles _search = Vehicles.MC; _search < Vehicles.Last; _search++)
            {
                int _count = 0;
                vehicles.ForEach(v => { if (v == _search) _count++; });
                Console.WriteLine($"{_search,10}: {_count}");
            }


            
            
            //Alternativ 2
            int _count1 = 0;
            List<Action<Vehicles>> actions = new List<Action<Vehicles>>();
            for (Vehicles _search = Vehicles.MC; _search <= Vehicles.Scooter; _search++)
            {
                var _localSearch = _search; 
                actions.Add(v => { if (v == _localSearch) _count1++; });
            }

            foreach (Action<Vehicles> action in actions)
            {
                _count1 = 0;
                vehicles.ForEach(action); 
                Console.WriteLine($"{_count1}");
            }
           
        }
    }
}
//Exercises:
//