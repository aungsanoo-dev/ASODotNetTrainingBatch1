// See https://aka.ms/new-console-template for more information
using Newtonsoft.Json;

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

string jsonStr = File.ReadAllText("DreamDictionary.json");

var model = JsonConvert.DeserializeObject<DreamDictionaryResponseModel>(jsonStr);

var lst = model.BlogDetail.ToList();

Console.WriteLine(jsonStr);
Console.ReadLine();



public class DreamDictionaryResponseModel
{
    public Blogheader[] BlogHeader { get; set; }
    public Blogdetail[] BlogDetail { get; set; }
}

public class Blogheader
{
    public int BlogId { get; set; }
    public string BlogTitle { get; set; }
}

public class Blogdetail
{
    public int BlogDetailId { get; set; }
    public int BlogId { get; set; }
    public string BlogContent { get; set; }
}
