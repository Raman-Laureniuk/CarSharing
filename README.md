# About
Example of car sharing service that allows to rent a car and manage cars and users.

# Project Structure

## Overview
CarSharing solution is implemented as a layered DDD-micorservice. It's structure is following:
- Application
  - CarSharing.WebApi.Client
  - CarSharing.WebApi.Management
  - CarSharing.WebApi.Geo
  - CarSharing.WebApi.Common
- Domain
  - CarSharing.Domain
- Infrastructure
  - CarSharing.Infrastructure
  - CarSharing.Repository.Entity
- Tests
  - UnitTests
    - CarSharing.Domain.UnitTests

## Application
Application layer implements microservice's interaction via WebAPI projects that are used from the UI or client apps.

### CarSharing.WebApi.Client
API for client's mobile app.

### CarSharing.WebApi.Management
API for management UI.

### CarSharing.WebApi.Geo
API for setting and updating car coordinates.

### CarSharing.WebApi.Common
Contains common WebAPIs things like handlers, role names, DI configuration, etc.

## Domain
Domain layer implements business logic and contains interfaces for repositories and providers.

### CarSharing.Domain
Contains business logic and interfaces for repositories and providers

## Infrastructure
Infrastructure layer implements data persistence and communication with external services and resources.

### CarSharing.Infrastructure
Implements communication with external services and resources.

### CarSharing.Repository.Entity
Implements data persistense via Entity Framework Core.

## Tests
Contains tests for solution.

### CarSharing.Domain.UnitTests
Contains unit tests for CarSharing.Domain project.

# Patterns Used
Dependency Injection, Factory, Repository, Unit of Work, Decorator, Command, Data Transfer Object, Singleton, Adapter.
