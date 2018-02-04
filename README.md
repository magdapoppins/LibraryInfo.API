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

```GET api/cities/{cityId}/libraries``` - Gets the cities associated list of libraries.  
```POST api/cities/{cityId}/libraries``` - Adds a new library to the cities list of libraries.  
```PUT api/cities/{cityId}/libraries``` - Updates the library of a specific city.  
```PATCH api/cities/{cityId}/libraries``` - Partially updates the library of a specific city.  
```DELETE api/cities/{cityId}/libraries``` - Deletes the library of a specific city.  


### HATEOAS in this project
This application uses Hyperlinks As The Engine Of Appilication State (HATEOAS). Every JSON object retreived from the repository contains links to the other actions related to that resource. This allows the application to evolve without setting complex requirements on the frontend architecture.

### Prerequisites
This app is built using Visual Studio 2017 Community Edition. It depends on components from the ASP.NET Core Metapackage, such as Entity Framework Core and LINQ. You will be able to run this project on a Windows machine or on Mac (Visual Studio for Mac) or Linux (by the .NET Core cross-platform feature). 

### Installation
If you have GIT installed, you can clone this project by the command ```git clone ```. After cloning the project, you can open the .sln file in Visual Studio and build it by running ```ctrl + shift + B```. At the first build, the database is created by the Entity Framework Code First -functionality. The connection string needs to be included in the project properties. The default connection string for the local SQL Server Management Studio is ```"Database:(mssqllocaldb)\\localdb;Table:MemberBase;Trusted_connection:True;"```. 

## Testing

### What tests this project features
This project includes a set of unit tests, which are built for the purpose of checking the 

### How to run the tests
For running the tests, you will need NLog.

## Deployment instructions
The deployment of this project is done by selecting "publish" from the list of alternatives that appears by right-clicking the project folder. Select the method of deployment which suits you and 


## Built with
Entity Framework Core 
.NET Core


## Acknowledgements
This project follows the many wise guidelines and instructions of the developer community centered around REST Api:s. Special thanks to []() and []() for their courses and blogposts about API creation and styleguides. Thanks to the style directives of [Adidas API Styleguide]() for many good tips. I also want to mention the [Copenhagen REST API meetup]() and recommend them to anyone interested in API creation and refinement. 
