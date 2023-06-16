# Project: Library Management System

This project is an implementation of a library management system using ASP.NET Core Web App (Model-View-Controller) framework and .NET 7.0, with a backend database managed using Entity Framework Core 7. The project covers a broad range of functionalities for different user roles such as visitors, employees, and administrators of the library. 

The main features of this project include:

- Item and author browsing
- Item reservation
- Management of loans and reservations
- Inventory management
- Payment processing
- User management
- Access control for different user roles
- Detailed project development history through Git

Please take note that due to backend issues, the `Abonnementen` are currently view-only. Furthermore, Dutch terminology was used in the initial structure of the diagrams due to a misunderstanding and will not be repeated in future projects.

## Prerequisites

- .NET 7.0
- ASP.NET Core Web App (Model-View-Controller) framework
- Entity Framework Core 7
- Visual Studio
- SQL Server (localdb)

## Starting Up the Project

1. Clone the repository to your local machine.
2. Open the project in Visual Studio.
3. Open the Package Manager Console and run the `update-database` command. This will create the database and run all migrations.
4. Start the project by pressing the 'IIS Express' button or by pressing F5. 

## Using the seeded Bezoeker, Medewerker and Beheerder accounts:

For using a seeded Bezoeker account, log in as User1@example.com Password: Password123!

For using a seeded Medewerker account, log in as Medewerker@example.com Password: Password123!

For using a seeded Beheerder account, log in as Admin@example.com Password: Password123!

## Running Tests

This project also includes NUnit tests located in the test project directory. To run these tests:

1. In Visual Studio, right-click on the solution in Solution Explorer.
2. Select 'Run Tests'.

These tests will provide insights into different functionalities of the application.

## Contact

For any queries regarding this project, please feel free to contact the development team.

## Contributors

* Robin Kantier - S1186143
* Quinten Schaap - S1190289

*Remember: Academic honesty is crucial. Any form of plagiarism will be reported to the academic board.*

## License

This project is licensed under the MIT License.
