# Restaurant Management System

# About this Project

The idea of the application is to allow Restaurants to do the Ordering and Stock Management through this system.

This project is a **Work In Progress** and part of my portfolio. I'll be happy if you could provide any feedback about the project, code, structure, or anything that you can report that could make me a better developer!

The main purpose of this application is to learn how to build better RESTful APIs following the OpenAPI specification, and practice Architecture, Design and Development Principles like TDD, SOLID, KISS, YAGNI, and DRY.

I'm posting my progress on my [Twitter account](https://twitter.com/gabrielpiccolo4).

# Design Decisions and Dependencies

I designed this application based on the [Common web application architectures](https://docs.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/common-web-application-architectures) from Microsoft Docs.

## The Web Project

The project is responsible for the host of the application and for all the initial configurations of it, which includes `Startup.cs`, `appsettings.json` file plus environment variables in the `secrets.json` file. It references the Api, Data and Services Project.

## The Api Project

The entry point of the application is the Api Project, which includes Controllers and Filters. It references the Services and Common Project.

## The Services Project

The project holds the business model, which includes Entities, Services, Interfaces, and DTOs. It references the Common Project.

## The Data Project

The project includes data access implementations, which includes the Database Context (currently MongoDB), Repositories and the implementations of the Options Pattern. It references the Services and Common Project.

## The Common Project

The project includes types that would likely be shared between multiple projects.

# Built With
- [ASP.NET Core 3.1](https://github.com/dotnet/aspnetcore) - Backend Framework
- [OpenAPI](https://swagger.io/specification/) - OpenAPI Specification using the Swashbuckle implemention
- [MongoDB](https://www.mongodb.com/) - Database
- [ReactJS](https://reactjs.org/) - Frontend Framework
- [Axios](https://github.com/axios/axios/) - HTTP Client
- [Reactstrap](https://reactstrap.github.io/) - React Bootstrap 4 components
- [ESlint](https://eslint.org/) - Linter
- [Prettier](https://prettier.io/) - Code Formatter
- [Yarn](https://yarnpkg.com/) - Package Manager
