# Enitity Framekwork - Databse Design

## Technologies

-   [.NET 5](https://dotnet.microsoft.com/download)
-   [ASP.NET Core 5](https://docs.microsoft.com/en-us/aspnet/core)
-   [Entity Framework Core 5](https://docs.microsoft.com/en-us/ef/core)

## Practices

-   one-to-one, one-to-many, many-to-many relationship databse design
-   code first entity frmamework approach
-   Data seeding

## Run

<details>
<summary>Visual Studio</summary>

#### Prerequisites

-   [Visual Studio](https://visualstudio.microsoft.com/downloads/)
-   [.NET 5 SDK](https://dotnet.microsoft.com/download/dotnet/5.0)
-   [SQL Server](https://go.microsoft.com/fwlink/?linkid=866662)

#### Steps

1. Open **EntityFramework.Database.Design.sln** in Visual Studio.
2. Open nuget package console
3. Run commands migration commands  
   `Add-Migration InitialCreate`  
   `Update-Database`
4. Verify that database is created with seed dada
5. Run the project

</details>

<details>
<summary>Visual Studio Code</summary>

#### Prerequisites

-   [.NET 5 SDK](https://dotnet.microsoft.com/download/dotnet/5.0)
-   [SQL Server](https://go.microsoft.com/fwlink/?linkid=866662)
-   [Visual Studio Code](https://code.visualstudio.com)
-   [C# Extension](https://marketplace.visualstudio.com/items?itemName=ms-vscode.csharp)

#### Steps

1. Open directory **entity-framework-database-design** in vs code
2. Open Integrated Terminal under **EntityFramework.Database.Design** directiory
3. Run commands migration commands  
   `dotnet tool install --global dotnet-ef `  
   `dotnet ef migrations add InitialCreate `  
   `dotnet ef database update`
4. Verify that database is created with seed data

</details>

## Check Relationship

<details>
<summary>One to Many relationship</summary>

#### Department and Employee

-  One Employee is associated only one department
-  One Department has many Employees
-  So we need to add reference in Employees (many) table

#### Employee table after seeding

![one-to-many](./resources/one-to-many.jpg)

</details>

<details>
<summary>Visual Studio Code</summary>

#### Prerequisites

-   [.NET 5 SDK](https://dotnet.microsoft.com/download/dotnet/5.0)
-   [SQL Server](https://go.microsoft.com/fwlink/?linkid=866662)
-   [Visual Studio Code](https://code.visualstudio.com)
-   [C# Extension](https://marketplace.visualstudio.com/items?itemName=ms-vscode.csharp)

#### Steps

1. Open directory **entity-framework-database-design** in vs code
2. Open Integrated Terminal under **EntityFramework.Database.Design** directiory
3. Run commands migration commands  
   `dotnet tool install --global dotnet-ef `  
   `dotnet ef migrations add InitialCreate `  
   `dotnet ef database update`
4. Verify that database is created with seed data

</details>
