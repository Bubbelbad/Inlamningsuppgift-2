
# Library Management - Clean Architecture 📚

This is a backend .NET 8 project for a library management application that manages digital books. 
The user can borrow and reserve digital books in different formats. 
It will be hosted on Azure and have a React FE application in the future. 

<br> 

## Featuring: 

- **CQRS with MediatR**: Implements the Command Query Responsibility Segregation (CQRS) pattern using MediatR.
- **GitHub Actions**: Automates your CI/CD pipeline with GitHub Actions for building, testing, and deploying your application.
- **Test Coverage (NUnit & FCC)**: Ensures code quality and reliability with comprehensive test coverage using NUnit and FluentAssertions.
- **ValidationBehavior with FluentValidation**: Integrates FluentValidation to provide a clean and extensible way to handle validation logic within your application.
- **OperationResult:** Standardizes the way results are returned from operations, encapsulating success and failure states along with relevant messages.
- **According to SOLID with Clean Code**
- **JWT Token Authentication**
<br>

<img src="https://github.com/Bubbelbad/Library-Management/blob/development/images/ClenArch.png" title="Clean Architecture" width="800" />&nbsp;

<br>

## Get Started

### Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) 
- [Visual Studio](https://visualstudio.microsoft.com/)
  
<br>

### Step 1: Clone the Repository
Clone the repository to your local machine:

```bash
  git clone https://github.com/Bubbelbad/Library-Management-System.git
```

<br>

### Step 2: Restore Dependencies
Restore the project dependencies using the .NET CLI:

```bash
  dotnet restore
```
<br>

### Step 3: Configure the Database
1. **Create a new `appsettings.Development.json`** in API layer:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=YourServer\\SQLEXPRESS; Database=YourDatabaseName; Trusted_Connection=true; TrustServerCertificate=true;"
  },
  "JwtSettings": {
    "SecretKey": "your_super_long_very_secret_key_etc"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

<br>

### Step 4: Apply Migrations
Use the following commands in the Developer PowerShell to update the database to the latest migration: 

```bash
  $env:ASPNETCORE_ENVIRONMENT = "Development"
```
```bash
  cd ./Infrastructure
```
```bash
  dotnet ef database update --startup-project ../API
```
<br>
  


