using System;
using System.Collections.Generic;

namespace ADOPM3_CodeExercises
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> myList = new List<int>(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });

            Action<int> DoOnEachElement = Write1;
            DoOnEachElement += Write2;
            DoOnEachElement += Write3;
            myList.ForEach(DoOnEachElement);
         
            
            Console.WriteLine();
            Predicate<int> Find = IsEven;
            Find += IsOdd;
            
            var myEvens = myList.FindAll(IsEven);
            myEvens.ForEach(DoOnEachElement);
            
        }
        static void Write1(int i)
        {
            Console.WriteLine($"number is {i}");
        }
        static void Write2(int i)
        {
            if (i % 2 == 0)
                Console.WriteLine($"number is even");
            else
                Console.WriteLine($"number is odd");
        }
        static void Write3(int i)
        {
            Console.WriteLine("---------");
        }

        static bool IsEven(int i) => i % 2 == 0;
        static bool IsOdd(int i) => i % 2 != 0;
    }
}
