// See https://aka.ms/new-console-template for more information
var p1 = new Person("Bruce Wyane", 32, Gender.male, /* Exercise 4 */ Goodbye);
var p2 = new Person("Marilyn Monroe", 30, Gender.female, /* Exercise 4 */ Goodbye);
var p3 = new Person("Kim Doe", 40, Gender.unknown, /* Exercise 4 */ Goodbye);

Console.WriteLine(p1);
Console.WriteLine(p2);
Console.WriteLine(p3);

/* Exercise 3 */
void Hello (Person p)
{
    if (p.PersonsGender == Gender.male)
    {
        Console.WriteLine($"Hello {p.Name}. You are {p.Age} years old!");
    }
    else if (p.PersonsGender == Gender.female)
    {
        Console.WriteLine($"Hello {p.Name}. You are beautiful!");
    }
    else
    {
        Console.WriteLine($"Hello {p.Name}");
    }
}

void Goodbye(Person p)
{
    Console.WriteLine($"Goodbye {p.Name}.");
}

/* Exercise 1 */
public delegate void CreationMessage(Person p);

public enum Gender { unknown, male, female}
public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
    public Gender PersonsGender { get; set; }

    public override string ToString() => $"Name: {Name} Age: {Age} Gender: {PersonsGender}";
    

    public Person (string name, int age, Gender gndr, /* Exercise 2 */ CreationMessage message)
    {
        Name = name;
        Age = age;
        PersonsGender = gndr;

        /* Exercise 5 */
        message(this);
    }
}



//Design recipe
//1. Define the delegate type (i.e., the function signature)
//2. Create a delegate object (variable) of the delegate type OR create the delegate object as a Method parameter
//3. Implement your Plug-In function(s) with the same signature as the delegate type
//4. Assign the Plug-In functions to the delegate object using “=”, “+=”, or “-=” operators OR invoke the Method with the plug-in as an argument
//5. Invoke the delegate object as a function using the function signature using of delegate type

//Exercise:
// Create a method that as a delegate to the Person class constructor, prints out a greeting to a newly create Person 
//1. Done, see above
//2. Create a delegate as a parameter in the constructor of Person in order to great the newly created person
//3. Create the Plug-In method to print-out a greetign message
//4. Modify the new Person() to take the plug-in as an argument
//5. In the constructor invoke the delegate

