// See https://aka.ms/new-console-template for more information
using Newtonsoft.Json;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

Console.WriteLine("Hello, World!");

Console.Write("Enter Mobile No:");
string mobileNo = Console.ReadLine()!;
HttpClient client = new HttpClient();
//var response = await client.GetAsync($"https://localhost:7135/api/CheckBalance/{mobileNo}");
//if(response.IsSuccessStatusCode)
//{
//    string jsonstr = await response.Content.ReadAsStringAsync();
//    Console.WriteLine(jsonstr);
//}

CheckBalanceRequestModel model = new CheckBalanceRequestModel
{
    MobileNo = mobileNo
};
var jsonCheckBalanceResponseModel = JsonConvert.SerializeObject(model);
var content = new StringContent(jsonCheckBalanceResponseModel, Encoding.UTF8, Application.Json);
var Task1 = client.GetAsync($"https://localhost:7135/api/CheckBalance/{mobileNo}");
var Task2 = client.PostAsync($"https://localhost:7135/api/CheckBalance", content);
var Task3 = client.GetAsync($"https://localhost:7135/api/CheckBalance/{mobileNo}");

await Task.Run(() => Task1);

DateTime startTime = DateTime.Now;
await Task.Run(() => Task1);
await Task.Run(() => Task2);
await Task.Run(() => Task3);
DateTime endTime = DateTime.Now;

var result = endTime - startTime;
Console.WriteLine(result.Milliseconds);

startTime = DateTime.Now;
await Task.WhenAll(Task1, Task2, Task3);
endTime = DateTime.Now;

 result = endTime - startTime;
Console.WriteLine(result.Milliseconds);

if (Task2.Result.IsSuccessStatusCode)
{
    string jsonstr = await Task2.Result.Content.ReadAsStringAsync();
    Console.WriteLine(jsonstr);
}

Console.ReadLine();
public class CheckBalanceRequestModel
{
    public string MobileNo { get; set; }
}

public class Method
{
    public async Task<int> Calculate(int a, int b)
    {
        return await Task.FromResult(a + b);
    }
}