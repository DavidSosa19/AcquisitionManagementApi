# API Documentation

## Prerequisites
Before running the API, ensure you have the following installed:
- .NET 9 
- PostgreSQL database
- NPGSQL

## Running the API

### Verify API is Running on Port 44363
Ensure that the API is correctly configured to run on port **44363**

### Database Connection
The API requires a connection to a PostgreSQL database. Ensure that your **PostgreSQL instance is running** and properly configured.

### Configuration
Modify the `appsettings.json` file to include the correct database connection string:

```json
"AllowedHosts": "*",
"ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=dbname;Username=username;Password=password"
}
```

Replace `dbname`, `username`, and `password` with the actual credentials of your PostgreSQL database.

### Automatic Database Generation
If the connection string is properly configured, the application will **automatically generate the database** upon startup using `EnsureCreated()`. If you need to apply migrations manually, run:

```sh
dotnet ef database update
```

## Running the API
To start the API, navigate to the project folder and run:

```sh
dotnet run
```

The API should now be accessible at `https://localhost:44363`.

## Testing the API
You can test the API endpoints using Postman, Swagger, or an Angular frontend.

For any issues, check the logs or ensure the database connection is correct.

