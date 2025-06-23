# SLH DotNetTraining

- C# Basic
- SQL Basic
- Console App
- Console App + Db (Memory Database)
- Console App + Db (SQL Server)
	- ADO.NET (CRUD)
	- Daper (CRUD)
	- EF Core (CRUD)
- Postman
- ASP.NET Core Web API
- HttpClient
- RestSharp
- Refit
- Console App + API

dotnet ef dbcontext scaffold "Server=.\SQL2022Express;Database=Northwind;User Id=sa;Password=sasa@123;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -o NorthwindModels -c NorthwindAppDbContext -f

dotnet ef dbcontext scaffold "Server=.\SQL2022Express;Database=DotNetTrainingBatch1;User Id=sa;Password=sasa@123;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -o Models -c AppDbContext -f

#Simple WebApi Project Note

- Database > Table
- Class Library > EFCore Install > Cmd
- API Project > Add Class Library > EFCore (DI)
- API Project > Add Controller > CRUD using AppDbContext
- Class Library > Domain > BlogService > API Project > Add > Register (builder.Services.AddScoped<BlogService>();))


> Database > Domain > API Project (DI)

dotnet ef dbcontext scaffold "Server=.\SQL2022Express;Database=MiniWallet;User Id=sa;Password=sasa@123;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -o AppDbContextModels -c AppDbContext -f

dotnet ef dbcontext scaffold "Server=.\SQL2022Express;Database=DreamDictionary;User Id=sa;Password=sasa@123;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -o AppDbContextModels -c AppDbContext -f
