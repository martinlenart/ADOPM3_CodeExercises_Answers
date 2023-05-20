namespace Async2;

class Program
{
    static async Task Main(string[] args)
    {
        string s1 = null, s2 = null, s3 = null;
        Task<string> t1 = null, t2 = null, t3 = null;
        try
        {
            Console.WriteLine("Syncronous calls");
            s1 = SayHello("Good Morning");
            Console.WriteLine(s1);

            s2 = SayHello("Good Afternoon");
            Console.WriteLine(s2);

            s3 = SayHello("Good Evening");
            Console.WriteLine(s3);

            Console.WriteLine("\n\nAsyncron calls, using await after each call");
            Console.WriteLine("Very similar to syncronous calls");
            s1 = await SayHelloAsync("Good Morning");
            Console.WriteLine(s1);
            s2 = await SayHelloAsync("Good Afternoon");
            Console.WriteLine(s2);
            s3 = await SayHelloAsync("Good Evening");
            Console.WriteLine(s3);


            Console.WriteLine("\n\nAsyncron calls, await on all tasks to complete");
            Console.WriteLine("All three tasks now run in parallell");
            Console.WriteLine("You cannot determine the order of execution, and indeed main terminated first");

            t1 = SayHelloAsync("Good Morning");
            t2 = SayHelloAsync("Good Afternoon");
            t3 = SayHelloAsync("Good Evening");

            //Here I way for all tasks to be completed, then write the result
            Console.WriteLine("\n\n---Main is now complete and waiting");
            await Task.WhenAll(t1, t2, t3);
            Console.WriteLine(t1.Result);
            Console.WriteLine(t2.Result);
            Console.WriteLine(t3.Result);

        }
        catch (Exception ex)
        {
            //Your code
            Console.WriteLine(ex.Message);
        }
        finally
        {
            Console.WriteLine("Main terminated");
            Console.ReadLine();
        }
    }

    //making an async method from the sync
    static public Task<string> SayHelloAsync(string message) =>
        Task.Run(() => SayHello(message));

    //here is the sync method
    static public string SayHello(string message)
    {
        var rnd = new Random();
        int c = 0;
        for (int i = 0; i < 100_000; i++)
        {
            if (i%20_000 == 0)
                Console.WriteLine($"{c++,4}:{message}");

            Task.Delay(rnd.Next(10, 2000));
        }
        return $"All good saying: {message}";
    }
}

