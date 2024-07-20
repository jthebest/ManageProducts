@echo off

rem install packages Cors
dotnet add package Microsoft.AspNetCore.Cors --version 2.2.0

rem install packages API
dotnet add package Microsoft.AspNetCore.OpenApi --version 8.0.7

rem install packages EntityFramework Desing
dotnet add package Microsoft.EntityFrameworkCore.Design --version 8.0.0

rem install packages EntityFramework Mysql
dotnet add package Pomelo.EntityFrameworkCore.MySql --version 8.0.2

rem install packages swagger
dotnet add package Swashbuckle.AspNetCore --version 6.3.0


rem Restore packages
dotnet restore

rem Build the project
dotnet build

rem Run migrations (if applicable)
rem Replace with your specific migration command if needed
dotnet ef database update

rem Run the ASP.NET Core application
dotnet run --project ManageApi.csproj
