# ASP.NET Core — Clean Architecture Example

A concise, production-oriented example of Clean Architecture implemented with ASP.NET Core and Azure Cosmos DB. The solution demonstrates separation of concerns across layers (Web/API, Application, Domain, Infrastructure), the Repository Pattern to decouple persistence, and dependency injection for testability and composition.

## Table of Contents

- [Overview](#overview)  
- [Architecture](#architecture)  
- [Repository Pattern](#repository-pattern)  
- [Dependency Injection](#dependency-injection)  
- [Tech Stack](#tech-stack)  
- [Getting Started](#getting-started)  
- [Project Pointers](#project-pointers)  
- [Contributing](#contributing)  
- [License](#license)

## Overview

This repository targets .NET 8 and shows how to structure a web API using Clean Architecture principles: keep domain and application logic independent from infrastructure concerns so the core is easy to test and evolve.

## Architecture

Layers:
- Presentation (Web/API): HTTP endpoints and request composition.
- Application: Use cases, DTOs, interfaces (contracts) for services and repositories.
- Domain: Entities, value objects, business rules.
- Infrastructure: External systems (persistence, messaging, external APIs).

This separation allows the Application layer to depend only on abstractions (interfaces). Concrete implementations live in Infrastructure and are registered into the DI container at startup.

## Repository Pattern

The Repository Pattern abstracts data access behind well-defined interfaces. Benefits:
- Encapsulates queries and persistence logic.
- Simplifies unit testing by allowing mocks/fakes.
- Centralizes data concerns and mapping.

Typical shape in this repo:
- Interface in Application project: e.g., `IStoryRepository`.
- Concrete implementation in Infrastructure: `StoryRepository` which uses `StoryCosmosContext` to operate on Azure Cosmos DB.

## Dependency Injection

This solution uses the ASP.NET Core built-in DI container. Register long-lived clients as singletons and request-scoped services as scoped.

Recommended registrations (example for .NET 8 `Program.cs`):

````````csharp
builder.Services.AddSingleton<CosmosClient>(provider =>
{
    var configuration = provider.GetRequiredService<IConfiguration>();
    return new CosmosClient(configuration["CosmosDb:Endpoint"], configuration["CosmosDb:Key"]);
});
builder.Services.AddScoped<StoryCosmosContext>();
builder.Services.AddScoped<IStoryRepository, StoryRepository>();
````````

## Tech Stack

- .NET 8
- ASP.NET Core Web API
- C# 12
- Azure Cosmos DB (Azure.Cosmos SDK)
- xUnit / NUnit (recommended for tests)
- Docker (optional)
- GitHub Actions / Azure DevOps (recommended CI)

## Getting Started

Prerequisites:
- .NET 8 SDK
- __Visual Studio 2026__ (or `dotnet` CLI)
- Azure Cosmos DB instance (or Cosmos DB emulator for local development)
