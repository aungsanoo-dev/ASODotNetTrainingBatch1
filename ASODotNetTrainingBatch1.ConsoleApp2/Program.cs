// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

using ASODotNetTrainingBatch1.ConsoleApp2;

//LoginDapperService service = new LoginDapperService();
//service.Read();

HomeworkService service = new HomeworkService();
//service.Read();
//service.Detail(1);
//service.Create();
//service.Login();
//service.Update();
service.LoginWithStoredProcedure();

//int originalNumber = 1;
//test(ref originalNumber);

//void test(ref int number)
//{
//    number = 10;
//}


//string originalString = "1";
//testr(ref originalString);

//void testr(ref string orgString)
//{
//    //orgString = "10";
//}

//string test3 = "";

//void test2(out string test)
//{
//    test = "10";
//}
//Console.WriteLine(test3);
//test2(out test3);

//Console.WriteLine(test3);

//Console.WriteLine("Original Number:" + originalNumber);
//Console.WriteLine("Original String:" + originalString);

Console.ReadLine();