# Job Candidate API

## Features

- ASP.NET Core 8 with C# 12
- Clean Architecture (API, Core, Infrastructure, Shared layers)
- Swagger API documentation
- Structured logging with Serilog
- Azure Application Insights integration
- CORS configuration
- Global error handling middleware
- Dependency Injection
- Entity Framework Core with SQL Server
- Mapster for efficient object mapping
- xUnit for unit testing
- API Rate limiting

## Project Structure

- `src/JobCandidate.Api`: API Controllers, Middleware, and Configuration
- `src/JobCandidate.Core`: Business logic, Interfaces, and Domain Models
- `src/JobCandidate.Infrastructure`: Data access, External service integrations
- `src/JobCandidate.Shared`: Common utilities, helpers, and constants
- `test`: Unit tests

## Prerequisites

- .NET 8 SDK
- Visual Studio 2022 or later / Visual Studio Code
- SQL Server

## Getting Started

1. Clone the repository
2. Install .NET 8 SDK
3. Configure `appsettings.json` and `appsettings.Production.json`
4. Run `dotnet restore` to restore dependencies
5. Run `dotnet run --project src/JobCandidate.Api` to start the application

## Configuration

- Set the `DatabaseProvider` in `appsettings.json` to your preferred database

## Database Migrations

To create and apply database migrations:

```bash
dotnet ef migrations add InitialCreate --project src/JobCandidate.Infrastructure --startup-project src/JobCandidate.Api
dotnet ef database update --project src/JobCandidate.Infrastructure --startup-project src/JobCandidate.Api
```

## Running Tests

```bash
dotnet test
```
## Continuous Integration and Deployment

This project uses GitHub Actions for automated building, testing, and deployment. The pipeline is configured to:

1. Build the project
2. Run all tests
3. Deploy to a staging environment on pushes to the `develop` branch
4. Deploy to production on pushes to the `main` branch (requires manual approval)

## Docker Deployment 
```bash
docker build -t job-candidate-api .
```

```bash
docker run -p 8080:8080 job-candidate-api
```



