// See https://aka.ms/new-console-template for more information

Action<int>[] action_tests = new Action<int>[3];

action_tests[0] = i => Console.WriteLine($"Hello {i}");
action_tests[0] += i => Console.WriteLine($"Goodbye {i}");
action_tests[0] += i => Console.WriteLine($"Hello again {i}");
action_tests[1] = i => Console.WriteLine($"Hello {i}");
action_tests[1] += i => Console.WriteLine($"Goodbye {i}");
action_tests[1] += i => Console.WriteLine($"Hello again {i}");
action_tests[2] = i => Console.WriteLine($"Hello {i}");
action_tests[2] += i => Console.WriteLine($"Goodbye {i}");
action_tests[2] += i => Console.WriteLine($"Hello again {i}");

Console.WriteLine("Action Delegates");
for (int i = 0; i < action_tests.Length; i++)
{
    action_tests[i](i);                 //All three Action execute
}

Console.WriteLine("\nFunc Delegates");


Func<int, string>[] func_tests = new Func<int, string>[3];
var Message = "My Message";

func_tests[0] = i =>
{
    Console.WriteLine($"Hello {i} {Message} executed but no return value");
    return $"Hello {i}";
};
func_tests[0] += (int i) =>
{
    Console.WriteLine($"Goodbye {i} executed but no return value");
    return $"Goodbye {i}";
};
func_tests[0] += i => $"Hello again {i}";

func_tests[1] = myfunc0;
func_tests[1] += myfunc1;
func_tests[1] += myfunc2; //last return string
func_tests[2] = myfunc0;
func_tests[2] += myfunc1;
func_tests[2] += myfunc2;//last return string
for (int i = 0; i < func_tests.Length; i++)
{
    Console.WriteLine(func_tests[i](i));  //All three Func execute but only string from last execute is returned 
}

string myfunc0(int i)
{
    Console.WriteLine($"Hello {i} {Message} executed but no return value");
    return $"Hello {i}"; 
}

string myfunc1(int i)
{
    Console.WriteLine($"Goodbye {i} executed but no return value");
    return $"Goodbye {i}"; 
}

string myfunc2(int i)
{
    Console.WriteLine($"Hello again {i} executed AND value returned");
    return $"Hello again {i}"; 
}



