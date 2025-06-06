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

Console.ReadLine();