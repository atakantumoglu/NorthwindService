


# Northwind Service with MediatR, CQRS, and DDD

<b>An educational .Net Core Api Project</b>
## Overview

This project offers a modern implementation of the Northwind database leveraging MediatR for mediator pattern, CQRS for clear separation of command and query responsibilities, and Domain-Driven Design for modeling complex business domains. This repository provides a clean and scalable approach to building CRUD operations on top of the Northwind database.

## Features

- **MediatR**: Implementing the mediator pattern to decouple request handling.
- **CQRS**: Separating read (query) and write (command) operations.
- **DDD**: Establishing a rich domain model to encapsulate business logic.
- **CRUD Operations**: All basic Create, Read, Update, and Delete operations are available for Northwind entities.

## Getting Started

### Prerequisites

- .NET Core SDK
- SQL Server (For Northwind database)

### Installation

1. Clone the repository:
git clone git@github.com:atakantumoglu/NorthwindService.git

2. Navigate to the project directory:
cd .\InventoryService.Api\

3. Restore packages and build the project:
dotnet restore
dotnet build

6. Start the application:
dotnet run

## Usage

Provide brief examples or API documentation on how to interact with your service. (e.g., API endpoints, request-response examples).

## Architecture

- **Presentation Layer**: Contains controllers.
- **Domain Layer**: Contains enterprise logic and types.
- **Application Layer**: This layer directs the expressed intent from the presentation layer to the domain layer.
- **Infrastructure Layer**: Contains everything that operates outside of the context of the domain.


## Contributing

Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.


