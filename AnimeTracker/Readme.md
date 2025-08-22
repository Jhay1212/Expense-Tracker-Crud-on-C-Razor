# ExpenseTracker

An ASP.NET Core Razor Pages application for tracking purchases and expenses.  
Built with **.NET 9**, **Entity Framework Core**, and **Microsoft SQL Server**.

## 📦 Prerequisites

I used dotnet 9 for this with razor template

- [.NET 9 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)  
  Verify with:

  dotnet --version

⚙️ Setup

Run the following after unpacking the project:

dotnet restore

Configure database according to your server instance in appsettings.json:

Server=localhost → your SQL Server instance
Database=ExpenseTrackerDb → the database name
User Id / Password → your SQL Server credentials

Example connection string:

"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=ExpenseTrackerDb;User Id=sa;Password=YourPassword;TrustServerCertificate=True;"
}

Install Entity Framework CLI:

dotnet tool install --global dotnet-ef

Update database schema:

dotnet ef database update

Run the development server:

dotnet watch run


Do you want me to also strip the emojis and headings (`📦`, `⚙️`) so it looks even more bareb