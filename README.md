# NZ_Walks

> A Web API for managing walking trails in New Zealand.

## ✨ Features

- **CRUD Operations** – Create, read, update, and delete walking trails
- **Filtering & Pagination** – (Work in Progress)
- **Authentication** – (Work in Progress)

## 🛠️ Tech Stack

- **.NET 8 SDK** – Web API framework
- **C#** – Programming language
- **MySQL 8.0** – Database

## 📦 Dependencies

- **.NET SDK 8.0** – Runtime and framework
- **MySQL Server 8.0** – Database (also compatible with MariaDB 10.5+)
- **Entity Framework Core 8.0** – ORM for database operations
- **Pomelo.EntityFrameworkCore.MySql 8.0** – MySQL provider for EF Core
- **Swashbuckle.AspNetCore** – Swagger/OpenAPI documentation

## 🚀 Installation

```bash
# Clone the repository
git clone https://github.com/danitdev/C-DotnetProjects

# Navigate to project folder
cd NZ_Walks

# Restore dependencies
dotnet restore

# Update database (if using migrations)
dotnet ef database update

# Run the API
dotnet run
