using ASODotNetTrainingBatch1;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

Homework.Main(new string[] { "arg1", "arg2" });

Product product = new Product(1, "P001", "Apple", 3000, 10, "Fruit");


BeforePrice:
Console.WriteLine("Input Product Quantity: ");
string quantityResult = Console.ReadLine();
decimal price = 0;
bool isDecimal = decimal.TryParse(quantityResult, out price);
if(!isDecimal)
{
    Console.WriteLine("Invalid price.");
    goto BeforePrice;
}

BeforeQuantity:
int quantity = 0;
bool isInt = int.TryParse(quantityResult, out quantity);
if (isInt)
{
    Console.WriteLine("Invalid Quantity");
    goto BeforeQuantity;
}

Data.ProductId++;

string productCode = "P001";

//Product product = new Product
//{
//    Id = 1,
//    Code = "P001",
//    Name = "Product 1",
//    Price = 10.99m,
//    Quantity = 100,
//    Category = "Category A",
//}
   
internal class Book
{
    private string booktitle;
    private int bookpages;
    public string BookTitle
    {
        get { return booktitle; }
        set
        {
            if (!string.IsNullOrEmpty(value))
            {
                booktitle = value;
            }
            else
            {
                throw new ArgumentException("Booktitle cannot be empty.");
            }
        }
    }
    public int Bookpages
    {
        get { return bookpages; }
        set
        {
            if (value >= 0)
            {
                bookpages = value;
            }
            else
            {
                throw new ArgumentException("Pages cannot be negative or zero");
            }
        }
    }

    public Book(string booktitle, int bookpages)
    {
        BookTitle = booktitle;
        Bookpages = bookpages;
    }

    public void describe()
    {
        Console.WriteLine($"The book '{booktitle}' has {bookpages} pages.");
    }
}

//File.WriteAllText("test.txt", "Hello World!");
//var result = File.ReadAllText("test.txt");
//Console.WriteLine(result);

//var result2 = str.Sum();

//int[] numbers = { 1, 2, 3, 4, 5 };

//foreach (var num in numbers)
//{
//    if (num % 2 == 0)
//    {
//        Console.WriteLine(num);
//    }
//}

//var lst = numbers.Where(x => x % 2 == 0);

//foreach (var num in lst)
//{
//    Console.WriteLine(num);
//}

//Console.WriteLine("Hello, World!");

//string name = "C";
//if (name == "A")
//{
//    Console.WriteLine("Run");
//}
//else if (name == "B")
//{
//    Console.WriteLine("Sleep");
//}
//else if (name == "C")
//{
//    Console.WriteLine("Eat");
//}
//else
//{
//    Console.WriteLine("Nothing");
//}

//switch (name)
//{
//    case "A":
//        Console.WriteLine("Run");
//        break;
//    case "B":
//        Console.WriteLine("Sleep");
//        break;
//    case "C":
//        Console.WriteLine("Eat");
//        break;
//    default:
//        Console.WriteLine("Nothing");
//        break;
//}

//for (int i = 1; i < 10; i++)
//{
//    Console.WriteLine("Before");
//    Console.WriteLine(i);
//    Console.WriteLine("After");
//}

//string[] str = { "A", "B", "C", "D" };
//for (int i = 0; i < str.Length; i++)
//{
//    Console.WriteLine(str[i]);
//}

//foreach (string item in str)
//{
//    Console.WriteLine(item);
//}

//int a = 1;
//try
//{
//    if (a == 1)
//    {
//        throw new Exception("heehee");
//    }
//}
//catch (Exception ex)
//{
//    Console.WriteLine("Something was wrong. ");
//}

//if(a == 1)
//{
//    throw new Exception("heehee");
//}

//Console.ReadLine();

//Resume resume = new Resume("Mg Mg", 18);
////Resume resume = new Resume();
////resume.Name = "Mg Mg";
//resume.SetAge(18);
////var result = resume.Is18Year();
//Console.WriteLine(resume.Name);
//Console.WriteLine(resume.Age);
//Console.WriteLine(resume.Is18);
////Console.WriteLine(result);


//Resume resume2 = new Resume("Ma Ma", 25);
////resume2.Name = "Ma Ma";
////resume.Age = 25;

//Dog dog = new Dog();
//dog.
//public class Resume
//{
//    //public Resume()
//    //{
//    //    Name = "None";
//    //}

//    public Resume(string name, int age)
//    {
//        Name = name;
//        Age = age;
//    }

//    public string Name { get; set; }
//    public int Age { get; private set; }

//    public bool Is18
//    {
//        get { return Age > 18; }
//    }

//    public void SetAge(int age)
//    {
//        Console.WriteLine($"Before {Age}");
//        Age = age;
//        Console.WriteLine($"After {Age}");
//    }

//    //public bool Is18Year()
//    //{
//    //    bool result = Age > 18;
//    //    return result;
//    //}
//}

//public class AAResume : Resume
//{
//    public AAResume(string name, int age) : base(name, age)
//    {
//    }
//}

//public class Animal
//{
//    public void Eat()
//    {
//        Console.WriteLine("Animal is eating. ");
//    }
//}

//public class Dog : Animal
//{
//    public void Bark()
//    {
//        Console.WriteLine("Dog is barking.");
//    }
//}

//public interface ITransfer
//{
//    void Create();
//    void Read();
//    void Update();
//    void Delete();
//}

//public class Kpay : ITransfer
//{
//    public void Create()
//    {
//        throw new NotImplementedException();
//    }
//    public void Delete()
//    {
//        throw new NotImplementedException();
//    }
//    public void Read()
//    {
//        throw new NotImplementedException();
//    }
//    public void Update()
//    {
//        throw new NotImplementedException();
//    }
//}

//int[] num = { 12, 22, 34, 43, 20};
//string[] names = { };
//decimal[] points = { };

//var ascendingOrder = num.OrderBy(nums => nums).ToArray();
//var descendingOrder = num.OrderByDescending(nums => nums).ToArray();
//var evenNums = num.Where(nums => nums % 2 == 0).ToArray();
//var twoTimes = num.Select(nums => nums * 2).ToArray();
//var firstElement = num.First();
//var firstOrDefault_int = num.FirstOrDefault(nums => nums > 5);
//var firstOrDefault_string = names.FirstOrDefault();
//var firstOrDefault_decimal = points.FirstOrDefault();
//var sum = num.Sum();
//var max = num.Max();
//var min = num.Min();
//var average = num.Average();
//var count = num.Count();

//Console.Write("Even Numbers: ");
//for (var i = 0; i < evenNums.Length; i++)
//{
//    Console.Write(evenNums[i]);
//    if (i < evenNums.Length - 1)
//    {
//        Console.Write(", ");
//    }
//}
//Console.WriteLine('\n');

//Console.Write("Multiply with Two: ");
//for (var i = 0; i < twoTimes.Length; i++)
//{
//    Console.Write(twoTimes[i]);
//    if (i < twoTimes.Length - 1)
//    {
//        Console.Write(", ");
//    }
//}
//Console.WriteLine('\n');

//Console.Write("Ascending Order: ");
//for (var i = 0; i < ascendingOrder.Length; i++)
//{
//    Console.Write(ascendingOrder[i]);
//    if (i < ascendingOrder.Length - 1)
//    {
//        Console.Write(", ");
//    }
//}
//Console.WriteLine('\n');