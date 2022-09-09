# Assesment Project 1
This is .net core backend service which calculates taxes applied in different municipalities. The taxes are scheduled in time. Service is providing the api to get taxes applied in certian muncipalities in a given day.

## Technology Used
- ASP.NET Core 5.0
- Entity Framework
- SQL Server

## Projects
- TaxCalculationApplication
- api-web-tests  

## Setup Instructions
- Clone this repository
- Replace database credentials, user and password with your SQL credentials  in app connection in **appsetting.json** file.
- Run update-database command in _Package Manager Console_ window.
> PM> update-database
- Goto SSMS and execute Sql script file [script.sql](https://github.com/Tripti-Pandey/AssesmentProject1/blob/main/TaxCalculationApplication/Script/script.sql) provided under **script folder** in solution.
- After this, run application.
- Check Test cases in XUnit test project.
