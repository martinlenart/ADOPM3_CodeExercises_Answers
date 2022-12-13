// See https://aka.ms/new-console-template for more information

using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string Message = "Martins hello";
                var t1 = Task.Run(() =>
                {
                    for (int i = 0; i < 5; i++)
                    {
                        Console.WriteLine($"{Message}{i} from Task1");
                        Task.Delay(200);
                    }

                    return "Task1 has completed";
                });
                Console.WriteLine(t1.Result);

                var t2 = Task.Run(() =>
                {
                    for (int i = 0; i < 10; i++)
                    {

                        Console.WriteLine($"{Message}{i} from Task2");
                        Task.Delay(1000);
                        if (i == 5)
                        {
                            //throw new Exception("Task2 has faulted");
                        }

                    }
                    return "Task2 has completed";
                });
                Console.WriteLine(t2.Result);

                var t3 = Task.Run(() =>
                {
                    for (int i = 0; i < 15; i++)
                    {
                        Console.WriteLine($"{Message}{i} from Task3");
                        Task.Delay(500);
                        if (i == 5)
                        {
                            //throw new Exception("Task3 has faulted");
                        }
                    }
                    return "Task3 completed";
                });
                Console.WriteLine(t3.Result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //    Console.WriteLine($"Task3 has faulted: {t3.IsFaulted}");
            }
            finally
            {
                Console.WriteLine("Main terminated");
                Console.ReadLine();
            }
        }
    }
}


