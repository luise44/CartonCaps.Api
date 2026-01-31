# CartonCaps.Api

?? Exercise Description

This exercise was divided into two main parts:

## API Specification

The first part focused on defining the API contract.
This included designing the endpoints, request and response models, and documenting the expected behavior using an API specification, which can be found here:
https://github.com/luise44/CartonCaps.Api/blob/master/ApiSpecification.yaml

## API Implementation

The second part consisted of developing the API application based on the defined specification.
The implementation was built using ASP.NET Core (.NET 8), following clean architecture principles and best practices for authentication, validation, and endpoint design.

CartonCaps.Api is a Web API built with **ASP.NET Core (.NET 8)**.  
It provides backend services for authentication, onboarding, and referral-related flows.

---

## ?? Project Structure

```
CartonCaps.Api
?
??? Controllers # API endpoints
??? Services # Business logic
??? Repositories # Data access abstractions
??? DTOs # Data Transfer Objects
??? Program.cs # Application entry point
??? appsettings.json # Configuration
```

---

## ?? Authentication

The API uses **JWT Bearer Authentication**.

### Access Swagger UI
https://localhost:7126/swagger


### Authorizing in Swagger
1. Click **Authorize**
2. Paste your token:
Bearer <your-jwt-token>

3. Click **Authorize** and call protected endpoints

---

## ?? Running the Project

### Run locally
```bash
dotnet restore
dotnet build
dotnet run
```

The API will be available at:

```bash
https://localhost:7126
```

?? Testing
The project follows these testing principles:

Unit tests for business logic (services)

```bash
dotnet test
```

?? Author
Luis Borrero
Senior .NET Developer