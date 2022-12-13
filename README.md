# Shifterr

Shifterr is a web app that allows organizations to easily manage their work schedules. It uses ASP.NET for data handling, MySQL for data storage, and Angular for the user interface. The app is built for multi-tenancy, meaning it is set up to work with a single data store for all organizations that use the application.

## Run Locally

To create a development environment for Shifterr, you will need the following

* [dotnet SDK](https://dotnet.microsoft.com/en-us/download)
* [EF Core Tools](https://learn.microsoft.com/en-us/ef/core/get-started/overview/install#get-the-entity-framework-core-tools)
* A MySQL server to connect to
* [Angular CLI](https://angular.io/cli)

#### Web API

Migrate Entity Framework to your MySQL server
```
dotnet ef database update
```
Run the application in development more
```
dotnet run
```

#### Web Interface
Run Angular server
```
ng serve
```