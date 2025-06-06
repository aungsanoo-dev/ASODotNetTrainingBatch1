// See https://aka.ms/new-console-template for more information


using ASODotNetTrainingBatch1.ConsoleApp3;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

Console.WriteLine("Hello, World!");

SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
{
    DataSource = ".\\SQL2022Express",
    InitialCatalog = "DotNetTrainingBatch1",
    UserID = "sa",
    Password = "sasa@123",
    TrustServerCertificate = true
};


using IDbConnection connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
connection.Open();
//var lst = connection.Query<Product>("Select * From Tbl_Product").ToList();

//foreach (var item in lst)
//{
//    Console.WriteLine(item.ProductId);
//}
string query = @"INSERT INTO [dbo].[Tbl_Product]
           ([ProductCode]
           ,[ProductName]
           ,[Price]
           ,[Quantity]
           ,[CreatedDateTime]
           ,[CreatedBy])
     VALUES
           (@Code
		   ,@Name
		   ,@Price
		   ,@Quantity
		   ,@CreatedDate
		   ,@CreatedBy)";
int result = connection.Execute(query, new Product
{
    ProductCode = "P001",
    ProductName = "Product 1",
    Price = 100,
    Quantity = 10,
    CreatedDate = DateTime.Now,
    CreatedBy = 1
});

SqlService sqlService = new SqlService();
sqlService.Query<Product>("Select * From Tbl_Product");
sqlService.Execute("SELECT * FROM Tbl_Product");

Product product = new Product
{
    ProductCode = "P001",
    ProductName = "Product 1",
    Price = 100,
    Quantity = 10,
    CreatedDate = DateTime.Now,
    CreatedBy = 1
};

Console.ReadLine();

public class Product
{
    public int ProductId { get; set; }
    public string ProductCode { get; set; } 
    public string ProductName { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public DateTime CreatedDate { get; set; }
    public int CreatedBy { get; set; }

    public override string ToString()
    {
        return base.ToString();
    }
}