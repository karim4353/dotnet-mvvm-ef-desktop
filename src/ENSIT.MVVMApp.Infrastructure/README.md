# Infrastructure (EF Core)

## Run migrations & seed
Install dotnet-ef tool if needed:
```
dotnet tool install --global dotnet-ef
```

Add migration (if you change model):
```
dotnet ef migrations add InitialCreate --project src/ENSIT.MVVMApp.Infrastructure
```

Apply migrations:
```
dotnet ef database update --project src/ENSIT.MVVMApp.Infrastructure --startup-project src/ENSIT.MVVMApp
```

Switch to SQL Server / PostgreSQL:
- Edit `appsettings.json` connection string.
- Replace `UseSqlite` with `UseSqlServer` or `UseNpgsql` in `DiExtensions.cs` and add corresponding provider package.
