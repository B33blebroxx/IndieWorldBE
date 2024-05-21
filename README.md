# Indie World Backend

## Overview

Indie World is a platform that centralizes information for indie wrestling promotions and their fans. This backend service handles the data management and API endpoints for managing promotions, shows, and performers.

- **ERD**: [Indie World ERD](https://dbdiagram.io/d/Indie-World-663fbbb99e85a46d5596466c)
- **Backend Repository**: [GitHub Repository](https://github.com/B33blebroxx/IndieWorldBE)

## Getting Started

### Prerequisites

Before you begin, ensure you have the following installed:

- [Visual Studio](https://visualstudio.microsoft.com/downloads)
- [.NET 8.0](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/)
- [PostgreSQL](https://www.postgresql.org/download/)
- [Postman](https://www.postman.com/downloads/)

### Installation

1. **Clone the repository**:
   ```sh
   git clone https://github.com/B33blebroxx/IndieWorldBE.git
   cd IndieWorldBE
   ```

2. **Configure the Database**:
   - Create a PostgreSQL database.
   - Update the connection string in `appsettings.json`:
     ```json
     {
       "ConnectionStrings": {
         "DefaultConnection": "Host=localhost;Database=IndieWorld;Username=yourusername;Password=yourpassword"
       }
     }
     ```

3. **Run Database Migrations**:
   ```sh
   dotnet ef database update
   ```

4. **Run the Application**:
   ```sh
   dotnet run
   ```

### API Documentation

Use Postman to explore and test the API endpoints. Import the provided Postman collection to get started quickly.

[<img src="https://run.pstmn.io/button.svg" alt="Run In Postman" style="width: 128px; height: 32px;">](https://god.gw.postman.com/run-collection/27995480-504913af-4dc9-49a4-aaee-f633329bbb78?action=collection%2Ffork&source=rip_markdown&collection-url=entityId%3D27995480-504913af-4dc9-49a4-aaee-f633329bbb78%26entityType%3Dcollection%26workspaceId%3D4436291b-d311-4c1b-b435-7e8fdaf412de)

### ERD

The Entity Relationship Diagram (ERD) for the Indie World backend can be found [here](https://dbdiagram.io/d/Indie-World-663fbbb99e85a46d5596466c).

## Project Structure

```plaintext
IndieWorldBE/
├── Controllers/
│   ├── FilterSearchApi.cs
│   ├── PerformerApi.cs
│   ├── PromotionApi.cs
│   ├── RoleApi.cs
│   ├── ShowApi.cs
│   ├── UserApi.cs
├── Models/
│   ├── Performer.cs
│   ├── Promotion.cs
│   ├── Show.cs
│   ├── User.cs
│   ├── Role.cs
├── Data/
│   ├── IndieWorldDbContext.cs
│   ├── SeedData.cs
├── Program.cs
├── Startup.cs
├── appsettings.json
```

### Key Components

- **Controllers**: Handle HTTP requests and responses.
- **Models**: Define the data structure.
- **Data**: Database context and seed data.
