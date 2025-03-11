# Dawstin-CPW219-eCommerceSite

## Dawstin's Game Art Nexus

### Project Description
Welcome to Dawstin's Game Art Nexus! This project showcases an eCommerce platform dedicated to selling unique Nintendo games and abstract art, along with a vibrant arcade and gallery experience. It includes:
- User registration and login
- Product listings with typical prices
- Shopping cart functionality
- Order management
- Integration with a payment gateway

### Prerequisites
- [.NET Core SDK](https://dotnet.microsoft.com/download) (version X.X or later)
- [Visual Studio](https://visualstudio.microsoft.com/) or another IDE supporting ASP.NET Core
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) or another compatible database system

### Running the Project Locally
1. Clone the repository:
    ```sh
    git clone https://github.com/yourusername/Dawstin-CPW219-eCommerceSite.git
    cd Dawstin-CPW219-eCommerceSite
    ```
2. Restore dependencies:
    ```sh
    dotnet restore
    ```
3. Update the database connection string in the `appsettings.json` file.
4. Apply database migrations:
    ```sh
    dotnet ef database update
    ```
5. Build and run the project:
    ```sh
    dotnet run
    ```

### Useful Resources
- [ASP.NET MVC](https://docs.microsoft.com/en-us/aspnet/core/mvc/overview?view=aspnetcore-5.0)
- [CRUD Functionality](https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/crud?view=aspnetcore-5.0)
- [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/)

## Optional
- Build Status ![Build Status](https://img.shields.io/badge/build-passing-brightgreen)
- License ![License](https://img.shields.io/badge/license-MIT-blue)
