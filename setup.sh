#!/bin/bash

echo "Starting setup..."

# Check if dotnet is installed
if ! command -v dotnet &> /dev/null
then
    echo ".NET SDK not found. Please install .NET 8 SDK first:"
    echo "https://learn.microsoft.com/en-us/dotnet/core/install/linux"
    exit 1
fi

# Restore dependencies
echo "Restoring project dependencies..."
dotnet restore

# Build project
echo "Building the project..."
dotnet build

# Run project
echo "Running the project..."
dotnet run --project TariffComparisonService

echo "Setup complete. Application is now running."