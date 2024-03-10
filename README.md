# Book Collection (iSX Financial Test)

## Technologies
- ASP .NET Core 6
- Entity Framework Core 6
- Entity Framework Core Sql Server
- Swagger
- Swagger UI
- AutoMapper
- Newtonsoft.Json

## How to run it
### Run with MSSQL and Docker
- Navigate to the root directory of the project
- Run the following command to start the container ```docker-compose up -d```

#### MSSQL Information
- MSSQL credentials are (Username: sa, Password: Youtpassword123!)
- Port MSSQL listening to ```1433```
- Databese name: ```isx-db```

#### Code changes
- Navigate inside the ```Program.cs```
- Comment out the following line: ```builder.Services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase(builder.Configuration.GetValue<string>("MemoryConnectionString")));```
- Uncomment out the following line ```builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetValue<string>("DbConnectionString")));```

### Run with Memory Database
#### Code changes
- Navigate inside the ```Program.cs```
- Uncomment out the following line: ```builder.Services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase(builder.Configuration.GetValue<string>("MemoryConnectionString")));```
- Comment out the following line ```builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetValue<string>("DbConnectionString")));```

## Easy way to test the API
- Start the Project
- Using a browser navigate to (Swagger UI) https://localhost:7111/swagger/index.html
- Use the controllers appears on Swagger UI to test the project
