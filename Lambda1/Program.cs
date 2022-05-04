using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        public enum Vehicles { MC, Car, Scooter};
        static void Main(string[] args)
        {
            List<int> myList = new List<int> { 1, 2, 3, 4, 2, 6, 7, 3, 6, 8, 9 };
            
            int SearchVar = 3;
            int CountVar = 0;
            myList.ForEach(n =>
            {
                if (n == SearchVar)
                    CountVar++;
            });
            Console.WriteLine($"The list has {CountVar} elements of {SearchVar}");

            var rnd = new Random();
            List<Vehicles> vehicles = new List<Vehicles>();
            for (int i = 0; i < 100; i++)
            {
                var v = (Vehicles) rnd.Next((int) Vehicles.MC, (int) Vehicles.Scooter + 1);
                vehicles.Add(v);
            }

            //Alternativ 1
            for (Vehicles _search = Vehicles.MC; _search <= Vehicles.Scooter; _search++)
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