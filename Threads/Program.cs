// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

string Message = "Martins hello";
var t1 = new Thread(arg =>
{
    for (int i = 0; i < 5; i++)
    {
        Console.WriteLine($"{Message}{i} from Thread1");
        Thread.Sleep(2000);
    }
});

var t2 = new Thread(arg =>
{
    for (int i = 0; i < 10; i++)
    {

        Console.WriteLine($"{Message}{i} from Thread2");
        Thread.Sleep(1000);
    }
});

var t3 = new Thread(arg =>
{
    for (int i = 0; i < 15; i++)
    {
    Console.WriteLine($"{Message}{i} from Thread3");
    Thread.Sleep(500);
}
});

t1.Start();
t1.Join();
t2.Start();
t3.Start(); 
    
Console.WriteLine("Main terminated");

static void Thread1(object arg)
{
    for (int i = 0; i < 5; i++)
    {
//        if (i == 2)
//            throw new Exception();
        Console.WriteLine($"Hello{i} from Thread1");
        Thread.Sleep(2000);
    }
}
static void Thread2(object arg)
{
    for (int i = 0; i < 10; i++)
    {
        Console.WriteLine($"Hello{i} from Thread2");
        Thread.Sleep(1000);
    }
}
static void Thread3(object arg)
{
    for (int i = 0; i < 15; i++)
    {
        Console.WriteLine($"Hello{i} from Thread3");
        Thread.Sleep(500);
    }
}


//Exercises
//1. Create and start a thread that loops 5 times and in each loop prints out "Hello{i} from Thread1" and sleeps 2 second
//2. Create and start a thread that loops 10 times and in each loop prints out "Hello{i} from Thread2" and sleeps 1 second
//3. Create and start a thread that loops 15 times and in each loop prints out "Hello{i} from Thread3" and sleeps 0,5 second
//4. Change the order of execution using Join so that thread2 and thread3 starts after thread1 has completed execution

//5. Throw a new Exception(); in thread1 after 2 loops, what happens

//6. remove the exceptions and change all threads to Lamda that captures a variable, Message, of type string from Main
//   and prints it out instead of "Hello"

