// See https://aka.ms/new-console-template for more information
using ASODotNetTrainingBatch1.Shared;
using Microsoft.Data.SqlClient;

Console.WriteLine("Hello, World!");

AdoDotNetService service = new AdoDotNetService(new SqlConnectionStringBuilder
{
    DataSource = ".\\SQL2022Express",
    InitialCatalog = "DotNetTrainingBatch1",
    UserID = "sa",
    Password = "sasa@123",
    TrustServerCertificate = true
});

service.Execute("insert into Tbl_User (UserName, Password) values (@UserName, @Password)",
    new SqlParameter("@UserName", "admin"),
    new SqlParameter("@Password", "admin"));
service.Query("select * from Tbl_User");

Console.ReadLine();