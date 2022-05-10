using System;
using System.Collections.Generic;

namespace Lambda0
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Exercises 1-3
            int[] numbers = new int[20];
            string[] cities = new string[20];

            //Random Initialization
            var rnd = new Random();
            var names = "Stockholm, Copenhagen, Oslo, Helsinki, Berlin, Madrid, Lissabon".Split(',');
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = rnd.Next(100, 1000 + 1);
                cities[i] = names[rnd.Next(0, names.Length)].Trim();
            }

            WriteLists(numbers, cities);
            #endregion

            #region Delegate1 Exercises 4-7
            Console.WriteLine("Delegates I Exercises");
            Console.WriteLine($"\n{nameof(numbers)} output by lambda");
            Array.ForEach(numbers, (int i) => Console.WriteLine(i));
            Console.WriteLine($"\n{nameof(cities)} output by lambda");
            Array.ForEach(cities, (string s) => Console.WriteLine(s));
            #endregion

            #region Delegate1 Exercises 8-9
            Console.WriteLine("\nDelegates II Exercises");
            var evenlist = Array.FindAll(numbers, (int item) => item%2 == 0);
            Array.ForEach(evenlist, (int i) => Console.WriteLine(i));

            Console.WriteLine();
            Array.ForEach(
                Array.FindAll(cities, (string item) => item.Length > 6),
                (string item) => Console.WriteLine(item));
            #endregion

            #region Delegate1 Exercises 10-11
            Console.WriteLine("\nDelegates III Exercises");
            Console.WriteLine(Array.Find(numbers, item => item > 500)); // Note that I can remove the item type
            Console.WriteLine(Array.FindLast(cities, item => item.Length > 8)); // Note that I can remove the item type
            #endregion
        }

        #region Delegate1 Exercises 1-3
        static void WriteLists(int[] _numbers, string[] _cities)
        {

            Console.WriteLine($"{nameof(_numbers)}:");
            foreach (var item in _numbers)
                Console.WriteLine(item);

            Console.WriteLine($"\n{nameof(_cities)}:");
            foreach (var item in _cities)
                Console.WriteLine(item);

        }
        #endregion
    }
}
//Exercises
//Starting point - together
//1.  Redo Exercises from Project Delegate1 using Lambda Expressions in all Array.ForEach(), Array.FindAll(),
//    Array.Find(), Array.FindLast()


