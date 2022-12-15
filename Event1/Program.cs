// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using System;

namespace Event1 // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
          Console.WriteLine("\nHuge friendlist");
            FriendList.CreationProgress += FriendList_CreationProgress;
          var huge = FriendList.Factory.CreateRandom(1_000_000);
        }

        private static void FriendList_CreationProgress(object? sender, int e)
        {
            Console.WriteLine($"completed {e} number");
        }
    }
}
//Exercise
//1. Implement the event handler and assign it to the event CreationProgress