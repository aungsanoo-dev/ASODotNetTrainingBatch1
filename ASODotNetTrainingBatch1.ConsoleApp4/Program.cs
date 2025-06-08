// See https://aka.ms/new-console-template for more information
using ASODotNetTrainingBatch1.ConsoleApp4;
using ASODotNetTrainingBatch1.Shared;
using Microsoft.Data.SqlClient;

Console.WriteLine("Hello, World!");

AppDbContext db = new AppDbContext();

// Read (Select)
var lst = db.ProductCategories.ToList();

foreach (var item in lst)
{
    Console.WriteLine(item.Name);
}

// Create (Insert)
var product = new ProductCategory
{
    Code = "PC004",
    Name = "Meat"
};

db.ProductCategories.Add(product);
int result = db.SaveChanges();

// Update 
var item2 = db.ProductCategories.FirstOrDefault(x => x.ProductCategoryId == 3);
if(item2 is null)
{
    Console.WriteLine("Item not found");
    return;
}
item2.Name = "Product Category 3";

int result2 = db.SaveChanges();

// Delete
var item3 = db.ProductCategories.FirstOrDefault(x => x.ProductCategoryId == 4);
if (item3 is null)
{
    Console.WriteLine("Item not found");
    return;
}
db.ProductCategories.Remove(item3);

int result3 = db.SaveChanges();

//var item3 = db.ProductCategories.FirstOrDefault(x => x.ProductCategoryId == 7);


//AdoDotNetService service = new AdoDotNetService(new SqlConnectionStringBuilder
//{
//    DataSource = ".\\SQL2022Express",
//    InitialCatalog = "DotNetTrainingBatch1",
//    UserID = "sa",
//    Password = "sasa@123",
//    TrustServerCertificate = true
//});

////service.Execute("insert into Tbl_User (UserName, Password) values (@UserName, @Password)",
////    new SqlParameter("@UserName", "admin"),
////    new SqlParameter("@Password", "admin"));
////service.Query("select * from Tbl_User");

//var lst = service.QueryV2<Product>("select * from tbl_product");
//foreach (var item in lst)
//{
//    Console.WriteLine(item.Name);
//}

Console.ReadLine();

//public class Product
//{
//    public int ProductId { get; set; }
//    public string ProductCode { get; set; }
//    public string ProductName { get; set; }
//    public decimal Price { get; set; }
//    public int Quantity { get; set; }
//    public DateTime CreatedDate { get; set; }
//    //public int CreatedBy { get; set; }

//    //public override string ToString()
//    //{
//    //    return base.ToString();
//    //}
//}