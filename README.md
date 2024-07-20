Manage Product App
Manage Product App is a full-stack application for managing products, consisting of both an Angular frontend and a .NET backend.

Table of Contents
Introduction
Features
Technologies Used
Setup Instructions
Project Structure
Usage
Contributing
License
Introduction
Manage Product App provides a user-friendly interface to manage products through a web application. It utilizes Angular for the frontend and .NET Core for the backend API.

Features
View a list of products
Add new products
Update existing products
Delete products
Technologies Used
Frontend (Angular)
Angular 17.3.0
Bootstrap 5.3.3
RxJS 7.8.0
Backend (.NET Core)
.NET 8.0
Entity Framework Core 6.0
ASP.NET Core Web API
Pomelo.EntityFrameworkCore.MySql 8.0.2 (MySQL database)
Setup Instructions
Prerequisites
Frontend (Angular)
Node.js and npm (Download Node.js)
Backend (.NET Core)
.NET SDK (Download .NET SDK)
MySQL Server (Download MySQL)
Installation
Clone the repository:

bash
Copy code
git clone https://github.com/jthebest/ManageProductApp.git
cd ManageProductApp
Backend Setup:

Navigate to the ManageApi directory for the .NET backend.

Update appsettings.json with your MySQL connection string.

Run the following commands:

bash
Copy code
dotnet restore
dotnet ef database update
dotnet run
Frontend Setup:

Navigate to the ManageProductAppFront directory for the Angular frontend.

Run the following commands:

bash
Copy code
npm install
npm start
Running the Application
The backend API will start on https://localhost:5001.
The Angular frontend development server will start on http://localhost:4200.
