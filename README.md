# Northwind API Service
![image](https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcSWsMsBO1BpbGdRWsXQ37QK01JhpdNUXAEFuWqdF1roFeelNUrT)

<b>An educational .Net Core API project</b>
## Overview
<!-- Optionally, you can put a logo related to Northwind or your project here -->

This project is an effort to modernize the classic Northwind database by building an API service using current and cutting-edge technologies. Developed using C#, ASP.NET Core 7, and EntityFramework Core, this API service aims to provide an experiential platform to interact with Northwind entities using a range of design patterns and architectural approaches.

## 🏗 Architecture

The project follows a layered architectural approach:

1. **Domain Layer**: This innermost layer hosts the Entities and Value Objects.
2. **Infrastructure Layer**: Connected to the Domain layer, it contains the Database Options Setup, Context objects, and entity configurations.
3. **Application Layer**: This is where the business logic of the application resides.
4. **Presentation Layer**: Comprises of the Controllers, which are responsible for returning the responses.

## 📐 Design Patterns and Approaches

- **Mediator Pattern** using MediatR.
- **Generic Repository Pattern**.
- **UnitOfWork Pattern** complementing the Generic Repository Pattern.
- **CQRS Pattern** (Command Query Responsibility Segregation).

## 📚 About the Northwind Database

By leveraging the Database First approach with the pre-existing Northwind database, I efficiently generated the required entities without the hassle of manual creation. This step was instrumental, providing a robust foundation without the need for direct database manipulation. Following this, I shifted towards the Code First paradigm. This transition wasn’t just a change in methodology; it represented an evolution in flexibility. By inheriting these entities from my custom BaseEntity class, I gained the capability to manage all database-related configurations directly from the code. This approach allowed for intricate enhancements and modifications without necessitating direct interventions in the database structure itself, epitomizing the union of convenience and control.

## 🚀 Getting Started

<!-- You might want to include steps for setting up the project locally, such as cloning the repository, installing dependencies, setting up the database, and running the application. -->

1. Clone the repository: `git clone https://github.com/atakantumoglu/NorthwindService.git`
2. Navigate to the project directory and install the dependencies.
3. Create a migration using .NET CLI or Package Manager Console.
4. Update Database with Initial migration.
5. Run the application using the appropriate command.
6. Explore the API documentation for available endpoints and functionalities.

## 🤝 Contribution

<!-- Optionally, you can add a section on how people can contribute, report issues, or request features. -->

Feel free to contribute to this project by submitting pull requests or reporting issues. Any feedback or suggestions are welcomed!


