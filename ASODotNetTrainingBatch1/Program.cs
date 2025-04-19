int[] str = { };
var result = str.FirstOrDefault();

Console.WriteLine(result); // Output: 0

decimal amount = 100000.90m; //m tells the compiler that this number is decimal. d for double. f for float.
Console.WriteLine(amount.ToString("n0"));

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