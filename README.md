### About

A REST API for the personal trainer program tracker frontend application to use for its backend. This project is implemented using ASP.NET Core Web API and Entity Framework Core with SQL Server.

### Architecture

I use ideas from the clean architecture and Onion architecture where I have a domain project consisting of pure C# code which includes entities and interfaces for infrastructure and application use cases.

One of the benefits of using clear seperation like this is that I could rework any of the layers without affecting the others. For example I could implement a Blazor or Razor pages Frontend without needing to touch the business logic or data access code.

I did originally plan to have the service/application layer coordinate data access using the unit of work pattern. However, I didn't wantthe application layer to depend on or know about Entity framework.
Therefore I created an interface for the unit of work so that it could be injected. However, I also wanted my endpoints to return resources after creating them. Because this abstraction stripped entity framework's tracking from the application layer, it meant that I couldn't get the created entity's Id easily. Therefore I decided to move data update coordination to the data access layer which meant beefier data methods which act more as specific business logic procedures rather than simple data access.
