// See https://aka.ms/new-console-template for more information
using ASODotNetTrainingBatch1.Database.Models;

Console.WriteLine("Hello, World!");

AppDbContext db = new AppDbContext();
db.TblProductCategories.Add(new TblProductCategory
{
    Code = "P001",
    Name = "Product 1"
});

db.SaveChanges();

db.TblProductCategories.FirstOrDefault(x => x.Id == 1);