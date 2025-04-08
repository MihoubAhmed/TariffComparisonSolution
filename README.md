# TariffComparisonService

This project was created as part of the Verivox application process.

It is an ASP.NET Core Web API developed in C# (.NET 8.0) for comparing electricity tariffs based on user consumption.

## Features

- Clean project structure (Controllers, Models, Services)
- RESTful API to calculate and compare tariff annual costs
- Extensible architecture using the Strategy Pattern
- Ready for extension: easily add new tariff types or products
- Swagger UI enabled for easy API exploration and testing
- Setup script (`setup.sh`) available for Linux/macOS environments

## Technologies

- ASP.NET Core Web API
- C# .NET 8.0
- REST API
- Swagger (OpenAPI)

## Getting Started

### Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)

### Clone the Repository

Clone the repository by running:

git clone https://github.com/MihoubAhmed/TariffComparisonSolution.git cd TariffComparisonSolution

## Setup Instructions for Linux/macOS

A `setup.sh` script is provided for Linux and macOS environments.

Make the script executable and run:
```sh
chmod +x setup.sh ./setup.sh
```
The script will:

- Check if .NET 8.0 is installed
- Restore NuGet packages
- Build the solution
- Run the application

## API Usage

Once the application is running, you can test the API using Swagger UI or directly with tools like Postman or browser.

Example API call:

GET https://tariff-comparison-app-a2gwhqgye3cuhkh5.germanywestcentral-01.azurewebsites.net/api/Tariff/compare?consumption=4500

This will return a JSON list of tariffs and their calculated annual costs based on the consumption input.

## Extending the Application

To add a new Tariff Type:

1. Create a new class implementing the `ITariffCalculationStrategy` interface.
2. Implement the logic inside `CalculateAnnualCost`.
3. Register the new strategy in `Program.cs` for Dependency Injection.
4. Add a new product with the corresponding `SupportedTariffTypeId`.

No existing code needs to be modified — simply extend!
