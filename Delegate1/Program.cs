using System;
using System.Collections.Generic;

namespace ADOPM3_CodeExercises
{
    class Program
    {
        static void Main(string[] args)
        {
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

            #region Exercise 4-7
            Console.WriteLine($"\n{nameof(numbers)} output by delegate");
            Array.ForEach(numbers, WriteInts);
            Console.WriteLine($"\n{nameof(cities)} output by delegate");
            Array.ForEach(cities, WriteString);

            Console.WriteLine($"\n{nameof(numbers)} output by generic delegate");
            Array.ForEach(numbers, WriteItem);
            Console.WriteLine($"\n{nameof(cities)} output by generic delegate");
            Array.ForEach(cities, WriteItem);
            #endregion
        }

        static void WriteLists(int[] _numbers, string[] _cities)
        {

            Console.WriteLine($"{nameof(_numbers)}:");
            foreach (var item in _numbers)
                Console.WriteLine(item);

            Console.WriteLine($"\n{nameof(_cities)}:");
            foreach (var item in _cities)
                Console.WriteLine(item);

        }

        #region exercise 4-7
        static void WriteInts(int myInt)
        {
            Console.WriteLine(myInt);
        }
        static void WriteString(string myString)
        {
            Console.WriteLine(myString);
        }
        static void WriteItem<T>(T item)
        {
            Console.WriteLine(item);
        }
        #endregion
    }
}
//Exercises
//Starting point - together
//1.  Create an int[] numbers, with 20 elements. Initialize each element with a random value between 100 and 1000
//2.  Create an string[] cities with 20 city names randomly assigned
//3.  Write a method that takes the two lists as parameters and print them out to the console using foreach loops.

//Delegates I
//4.  Explore Array.ForEach and write a delegate that prints numbers to the console using Array.ForEach()
//5.  Explore Array.ForEach and write a delegate that prints cities to the console using Array.ForEach()
//6.  Use Generics <T> to write one delegate that prints T[] to the console using Array.ForEach()
//7.  Print out both lists using the Method from 6.

//Delegates II
//8.  Explore Array.FindAll() and write a delegate returns an int[] of all even numbers.
//    Print out the new array using the pattern from 4 - 6
//9.  Explore Array.FindAll() and write a delegate returns an string[] of all cities with a name with more than 6 letters.
//    Print out the new array using the pattern from 4 - 6

//Delegates III
//10. Explore Array.Find() and write a delegate that finds the first number in numbers > 500. Print out the number
//11. Explore Array.FindLast() and write a delegate that finds the last city in the cities with a name longer than 8 letters


