// See https://aka.ms/new-console-template for more information
using Newtonsoft.Json;
using ASODotNetTrainingBatch1.Project2.Databases.AppDbContextModels;


string jsonStr = File.ReadAllText("DreamDictionary.json");

var model = JsonConvert.DeserializeObject<DreamDictionaryResponseModel>(jsonStr);

var lst1 = model.BlogHeader;
var lst2 = model.BlogDetail;

//Console.WriteLine(jsonStr);
//Console.ReadLine();

var _dbContext = new AppDbContext();

//foreach (var detail in lst2)
//{
//    var entity = new TblBlogDetail
//    {
//        BlogDetailId = detail.BlogDetailId,
//        BlogId = detail.BlogId,
//        BlogContent = detail.BlogContent
//    };
//    _dbContext.TblBlogDetails.Add(entity);
//}
//_dbContext.SaveChanges();

//foreach (var header in lst1)
//{
//    var entity = new TblBlogHeader
//    {
//        BlogId = header.BlogId,
//        BlogTitle = header.BlogTitle
//    };
//    _dbContext.TblBlogHeaders.Add(entity);
//}
//_dbContext.SaveChanges();

Console.WriteLine("Completed!");
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
