# Task Management
Task management application

This is the demo application for Task Management database 

## In order to run this you need the following things installed on your system 

1. .NET 6.0 SDK 
2. Visual Studio 2019/2022 or Visual Studio Code
3. A local instance of SQL Server database running.


## Database Structure

The database (TaskMgmt) of this application should contain 3 tables.  
- dbo.Tasks
- dbo.Steps
- dbo.TaskStatus

dbo.Tasks has the following columns 
- Id [INT and not null] - Primary Key
- Name [VARCHAR(MAX) not null]
- Description [VARCHAR(MAX) not null]

dbo.Steps
- Id [INT and not null] - Primary Key
- Serial [INT and not null]
- Description [VARCHAR(MAX) not null]
- TaskId [INT and not null] - Foreign Key 

dbo.TaskStatus (this table is prepopulated with data)
- Id [INT and not null] - Primary Key
- Status [VARCHAR(MAX) and nullable]
- Description [VARCHAR(MAX) and nullable]


## Database Migrations 

You need to run the follwoing command in the TaskManagement.Data directory to create the database. 
Make sure you have sql server running and the connection string is correctly updated in TaskManagementDbContext.cs file for it to run correctly 
```
dotnet ef database update
```
