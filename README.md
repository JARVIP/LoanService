# LoanService Project

## Prerequisites
- [Docker](https://www.docker.com/)
- [.NET 6 SDK or later](https://dotnet.microsoft.com/download)
- [Sencha Cmd](https://www.sencha.com/products/sencha-cmd/) (for client)

## Getting Started

### 1. Run Docker
Start the required services (e.g., database) using Docker Compose:
```sh
docker-compose up -d
```

### 2. Restore Backend Packages
Navigate to the project root and restore .NET dependencies:
```sh
dotnet restore
```

### 3. Update Database Migrations
Apply any pending migrations to the database:
```sh
cd src/LoanService.Api
dotnet ef database update
cd ../../
```

### 4. Run the Backend
Start the backend API:
```sh
cd src/LoanService.Api
dotnet run
```

### 5. Run the Client (Frontend)
Open a new terminal, navigate to the `client` folder, and start the frontend in watch mode:
```sh
cd client
sencha app watch
```

### 6. Enjoy!

## Notes
- Make sure Docker containers are running before starting the backend.
- Ensure you have Sencha Cmd installed and available in your PATH for client commands.
- For more details, see the `client/Readme.md` for frontend-specific instructions. 