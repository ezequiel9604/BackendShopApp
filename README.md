
# BackEndShopApp
This project will served as back-end server that provides data to the front-end.

## Recommended IDE Setup

[VSCode](https://code.visualstudio.com/) + plugins [C#], [ASP.NETHelper]

## Install dotnet-ef and add needed packages to project

```sh
dotnet tool install --global dotnet-ef
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer
dotnet add package System.IdentityModel.Tokens.Jwt
```

### Database and migration
Create the database first and add the connection string into 'appsettings.json' 
file with the database name

```sh
"ConnectionStrings": {
    "BackendShopAppConnectionString" : "Server=DESKTOP-Q3AQUO0\\SQLEXPRESS;Database=shopappdb;Trusted_Connection=True;",
    "EFbakendShopAppConnectionString" : "Server=DESKTOP-Q3AQUO0\\SQLEXPRESS;Database=efshopappdb;Trusted_Connection=True;",
    "[your_connection_string]":"Server=[SERVER_NAME];Database=[DATABASE_NAME];Trusted_Connection=True;"
}
```

```sh
dotnet-ef database update
```

### Build and run the app

```sh
dotnet run
```