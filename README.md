# Introduction

This is my backend project. I have built APIs that creates, reads, update and deletes from a local SQL database using EF core.

## :computer: Features!
- Usage of EF Core (Using code first migration!)
- End to end testing using Postman
- Comprehensive unit testing
- Usage of caching to speed up calls 
- Usage of API throttling to limit number of API requests per 5 seconds.
- Comprehensive unit testing (Fluent assertions, mock etc).
- Demonstration of BE logic (payroll type behavior)
- Onion structure using microservice pattern folder structure.

My APIs and data can interact with an external API (I used pokeApi: https://pokeapi.co/).

### Set up (EF Core - Code first migration!)
- You must have Microsoft SQL Server Management downloaded
- If you look at appsettings.json, the default connection string is set to "server=(localdb)\\mssqllocaldb. This means when you launch SQL the server name should be set to:    (localdb)\MSSQLLocalDB
- In package manager console, go into the server directory so : cd.\Andrew_SuperheroAPI
- Type:  dotnet ef database update
Build should succeed! You should be able to go into SQL now and edit the superherodb!


# Q&A Below!
### How does the middleware via dependency injection simlify my code?
Answer : Through dependency injection, you don't need to create instances of an object and therefore it makes my code loosely and easier to test as I can mock for unit test. So my assembly (service layer) is dependent on Pokemon and Superhero and to inject I created an interface for pokemon, superhero and assembly.
![image](https://user-images.githubusercontent.com/109708208/183777036-42eecabb-d498-423a-ae24-e78a3353a51e.png)

### Demonstrate the differences between starting the project with a configuration file over another
App settings can be used for complex configurations. If we deploy our app to different locations, it will have different information depending on where it is deployed to. Example, if we have sql server, depending on whether we are in the development environment or production environment we need our app to be configured to the correct environment. appsettings.json is global and will run first unless the environment is specified. 
In my file, appsettings.json has "Allowed Hosts": *  means it will get any host. If I had "Allowed Hosts": "example.com"    then my app won't be able to access at localhost:xxxx because the host filtering middleware is not allowing the app to bind to the other hostnames. I could've implemented this in the appsettings.development.json but it wouldn't be sensible because no testing would be able to be done. 


### Demonstrate use of NUnit to test code
Answer: Unit test's use is to ensure a function or a piece of code behaves as intended. NUnit is a unit testing framework for .net framework and most used for writing unit test cases. I unit tested adding a superhero ("Batman") which is a function I use in my service layer and in the superhero dependency. Also unit tested adding an Character object (superheroes are Character objects) and seeing if my Get function is working and returning correctly.


### Demonstrate how middleware libraries made your code easier to test
Answer: Middleware processes HTTP messages in .NET. SwaggerGen which is a component of Swashbuckle built SwaggerDocument object directly from my project routes, controllers and models. This is combined with the Swagger endpoint middleware. Having the SwaggerUI also allowed me to visualize and interact with the API's I created which made it easier for me to test my code as I could see if any interactions went wrong using when using my CRUD operations.


