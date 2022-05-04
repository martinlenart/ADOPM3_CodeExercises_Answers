using System;
using System.Threading;
using System.Threading.Tasks;

namespace Trains
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bullet Trains");
            Task<string>[] train = new Task<string>[10];
            for (int i = 0; i < 10; i++)
            {
                var k = i;
                (var fromCountry, var fromCity, var toCountry, var toCity) = RandomInit();

                train[k] = Task<string>.Run(() => TrainRide($"Train{k}", $"{fromCity} ({fromCountry})", $"{toCity} ({toCountry})"));
            }

            var idx = Task.WaitAny(train);
            Console.WriteLine($"\n%%First to arrive: {train[idx].Result}");

            Task.WaitAll(train);
        }

        private static string TrainRide(string trainName, string fromCity, string toCity)
        {
            var rnd = new Random();

            Console.WriteLine($"Train {trainName} departing {fromCity} to {toCity} at {DateTime.Now}");
            
            Thread.Sleep(rnd.Next(1000, 5000));
            var s = $"Train {trainName} arrived in {toCity} at {DateTime.Now}";
            Console.WriteLine(s);

            return s;
        }

        public static (string, string, string, string) RandomInit()
        {
            string[] _countries = "Sverige Norge Finland Lettland Tyskland Spanien".Split(' ');

            string[][] _cities = new string[_countries.Length][];
            _cities[0] = "Stockholm Malmo Gothenburg Gavle Linkoping Nykoping".Split();
            _cities[1] = "Oslo Tromso Haugesund Bergen".Split();
            _cities[2] = "Helsingfors Vaasa Oulu Tampere".Split();
            _cities[3] = "Riga Madona Daugavpils".Split();
            _cities[4] = "Dusseldorf Berlin Hannover Munich Hamburg".Split();
            _cities[5] = "Madrid, San Sebastian, Cordoba, Sevillia".Split(',');

            string fromCity, toCity, fromCountry, toCountry;
            fromCity = toCity = fromCountry = toCountry = null;

            var rnd = new Random();

            var _countryIdx = rnd.Next(0, _countries.Length);
            fromCountry = _countries[_countryIdx];
            fromCity = _cities[_countryIdx][rnd.Next(0, _cities[_countryIdx].Length)].Trim();

            _countryIdx = rnd.Next(0, _countries.Length);
            toCountry = _countries[_countryIdx];

            do
            {
                toCity = _cities[_countryIdx][rnd.Next(0, _cities[_countryIdx].Length)].Trim();
            }
            while (fromCity == toCity);

            return (fromCountry, fromCity, toCountry, toCity);
        }
    }
}
