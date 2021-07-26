# Cash Manger API
Author: Mike Ruckert

Date: 7/26/2021

Submitted for consideration of the position of Programmer and Systems Developer at K-MAR-105 Association.

This program is an API that supports user login and the maintenance of cash records.
It targets the .NET 5 framework.
To ensure completeness, I created a SQL Server database according to the table structure I was given.
For this, I used Microsoft SQL Server Management Studio and SQL Server 2019.
The database was hosted locally on my machine. The connection string can be found in the Connection.cs file.
 
For testing, I used Postman to submit HTTP requests to the API.
The API listens on http://localhost:5000. The endpoints "api/users", "api/records", "api/years", and "api/login" can be hit with HTTP requests.
The API expects the request body to be formatted as JSON. Notes on specific formatting can be found in each controller class.
