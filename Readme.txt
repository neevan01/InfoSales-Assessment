InfoSales Application Documentation

Overview
    InfoSales is a .NET Core application developed using .NET 6.0. 
    It provides a comprehensive sales management system featuring a dashboard with various data visualization components 
    and pages for managing customers, products, and transactions. The application utilizes Entity Framework (EF) Core 
    and Dapper for database interactions, along with stored procedures for certain operations.

Features
    Dashboard
        - Displays key metrics and visualizations using:
            - Cards
            - Spline Chart
            - Donut Chart
            - Grid

    Customers Page
        Search and manage customer details.

    Products Page
        Search and manage product information.

    Transactions Page
        Search and manage transaction records.

Technology Stack
    -NET Core 6.0
    -Entity Framework (EF) Core
    -Dapper
    -Chart.js for data visualization

Setup Instructions
Prerequisites
    -.NET 6.0 SDK
    -SQL Server
    -NuGet Package Manager

Steps to Setup the Project
Download the Project:
    -Clone or download the InfoSales project repository to your local machine.

Restore Database:
    -Locate the "InfoSales.sql" file inside the "InfoSales/Data" directory.
    -Run the script file using SQL Server Management Studio (SSMS) or any other SQL Server tool (file work well for 
        SQL version greater than or equal to 2014)

Update Connection String:
   -Open the "appsettings.json" file in the root directory of the project.
   -Modify the "ConnectionStrings" section to match your SQL Server configuration:
    
Restore NuGet Packages:
   -Open the solution in Visual Studio.
   -Restore the necessary NuGet packages by right-clicking on the solution and selecting "Restore NuGet Packages" 
    or using the Package Manager Console: "dotnet restore"

Run the Application:
   -Set the "InfoSales" project as the startup project.
   -Press "F5" or click on "Run" to start the application.

Login Information
    -Default Credentials:
        -Username: "aaaaa"
        -Password: "11111111"
    -You can also register a new user through the application's registration page.

Database Connection
    -The application uses EF Core and Dapper for database interactions using stored procedure.
    -EF Core is used directly in some pages.

Data Visualization
    -"Chart.js" is used for rendering charts and graphs on the dashboard.


Conclusion 
    This documentation provides an overview of the key features and technologies used, ensuring a smooth setup and 
    development process. For any further assistance, please refer to the comments within the code and additional 
    resources provided in the project repository.