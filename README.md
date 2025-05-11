# DaneshkarTeam1403.1

## Overview
DaneshkarTeam1403.1 is a web application built using ASP.NET Core. It provides functionalities for managing books, authors, categories, and keywords. The application is structured with areas for Admin and User, and includes features such as account management, book relations, and more.

## Features
- User and Admin areas with separate controllers and views.
- Book and author management.
- Category and keyword management.
- Database migrations for easy schema updates.
- Extensible service layer with interfaces and implementations.

## Project Structure
The project is organized as follows:
- **Controllers**: Handles HTTP requests and responses.
- **Data**: Contains database context and entity configurations.
- **Models**: Defines the data models used in the application.
- **Views**: Contains Razor views for rendering the UI.
- **Service**: Includes service interfaces and their implementations.
- **Tools**: Utility classes and extension methods.
- **wwwroot**: Static files such as CSS, JavaScript, and images.

## Prerequisites
- .NET 8.0 SDK
- A compatible database (e.g., SQL Server)

## Setup Instructions
1. Clone the repository:
   ```bash
   git clone https://github.com/Refhub-ir/DaneshkarTeam1403.1.git
   ```
2. Navigate to the project directory:
   ```bash
   cd DaneshkarTeam1403.1/Refhub_Ir
   ```
3. Restore dependencies:
   ```bash
   dotnet restore
   ```
4. Apply database migrations:
   ```bash
   dotnet ef database update
   ```
5. Run the application:
   ```bash
   dotnet run
   ```

## License
This project is licensed under the terms of the [LICENSE](./LICENSE) file.

## Contributing
Contributions are welcome! Please fork the repository and submit a pull request.

## Contact
For any inquiries or support, please contact the project maintainers.
