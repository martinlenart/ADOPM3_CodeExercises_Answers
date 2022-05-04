using System;
using System.Linq;

namespace Linq_Aggregate
{
    class Program
    {
        static void Main(string[] args)
        {
            //Using Linq Aggregate with Seed and Result LE
            string[] fruits = { "apple", "mango", "orange", "passionfruit", "grape" };

            //Determine whether any string in the array is longer than "banana".
            string longestName =
                fruits.Aggregate("banana",
                                (longest, next) =>
                                    next.Length > longest.Length ? next : longest,
                                // Return the final result as an upper case string.
                                fruit => fruit.ToUpper());

            Console.WriteLine($"The fruit with the longest name is {longestName}.");


            //Using Linq Aggregate with Seed 
            int[] ints = { 4, 8, 8, 3, 9, 0, 7, 8, 2 };

            //Count the even numbers in the array, using a seed value of 0.
            int numEven = ints.Aggregate(0, (total, next) =>
                                                next % 2 == 0 ? total + 1 : total,
                                                res=>res*2) ;

            Console.WriteLine($"The number of even integers is: {numEven}");
        }
    }
}
