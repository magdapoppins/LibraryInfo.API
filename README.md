# Library Info API and Repository
A RESTfulish API and entity repository for CRUD on library data in .NET Core.

## Getting started

### Accessing the endpoints
The endpoints of this API allow it's consumers to create, read, update and delete resources from the database. The endpoints and their respective HTTP verbs are as follows:

```GET api/cities``` - Gets a list of cities from the data repository.  
```GET api/cities/{cityId}``` - Gets a city by ID.  
```POST api/cities``` - Creates a new city from the request body.  
```PUT api/cities/{cityId}``` - Updates a city by ID.  
```PATCH api/cities/{cityId}``` - Partially updates a city by ID.  
```DELETE api/cities/{cityId}``` - Deletes a city by ID.  

```GET api/cities/{cityId}/libraries``` - Gets a list of libraries of a specified city.  
```GET api/cities/{cityId}/libraries/{id}``` - Gets a library by it's id.  
```POST api/cities/{cityId}/libraries``` - Adds a new library to the cities list of libraries.  
```PUT api/cities/{cityId}/libraries/{id}``` - Updates the library of a specific city.  
```PATCH api/cities/{cityId}/libraries/{id}``` - Partially updates the library of a specific city.  
```DELETE api/cities/{cityId}/libraries/{id}``` - Deletes the library of a specific city.  


### REST in this project
Although this project doesn't implement REST completely, it has several RESTful qualities. Out of the six REST constrains, this project implements the following:  
1) Client-Server-separation  
2) Statelessness  
3) Uniform contract (HATEOS still in progress)  
4) Cacheability (not implemented)  
5) Layered design  
6) Code on Demand (not implemented)  


### Prerequisites
This app is built using Visual Studio 2017 Community Edition. It depends on components from the ASP.NET Core Metapackage, such as Entity Framework Core and LINQ. You will be able to run this project on a Windows machine or on Mac (Visual Studio for Mac) or Linux (by the .NET Core cross-platform feature). 

### Installation
If you have GIT installed, you can clone this project by the command ```git clone https://github.com/magdapoppins/LibraryInfo.API.git```. After cloning the project, you can open the .sln file in Visual Studio and build it by running ```ctrl + shift + B```. At the first build, the database is created by the Entity Framework Code First -functionality. The connection string needs to be included in the project properties. The default connection string for the local SQL Server Management Studio is ```"Server=(localdb)\\mssqllocaldb;Database=LibraryInfoDB;Trusted_connection=True;"```. 

## Testing  

### What tests this project features
*Work in progress*

## Deployment instructions
The deployment of this project is done by selecting "publish" from the list of alternatives that appears by right-clicking the project folder. The project can be deployed on IIS, Windows Service, Ngix or Apache. Instructions for deployment can be found [here](https://docs.microsoft.com/en-us/aspnet/core/host-and-deploy/?tabs=aspnetcore2x). 

## Built with
Entity Framework Core 
.NET Core

## Acknowledgements
This project follows the many wise guidelines and instructions of the developer community centered around REST Api:s. Special thanks to [Kevin Dockx](https://www.kevindockx.com/) and [Shawn Wildermuth](https://wildermuth.com/) for their courses and blogposts about API creation and design. Thanks to the style directives of [Adidas API Styleguide](https://adidas-group.gitbooks.io/api-guidelines/content/) for many good tips. I also want to mention the [Copenhagen REST API meetup](https://www.meetup.com/REST-API-Meetup-Location-in-Copenhagen-Aarhus-and-Aalborg) and recommend them to anyone interested in API creation and refinement. 
