# Academique.MVVMApp - .NET MVVM Desktop Sample (Academic Project)

**Elevator pitch:** A compact WPF desktop application demonstrating MVVM, EF Core (SQLite), DI, Serilog logging, async/await and performance-focused data access. This repo is an academic-quality demo you can run locally and inspect.

## Technologies
- .NET 7 (WPF)
- C# 10
- WPF (MVVM)
- Entity Framework Core 7 (SQLite)
- xUnit for tests
- Serilog (console + file)
- Microsoft.Extensions.DependencyInjection / Host
- Optional: dotnet-ef tool

## Quickstart (build & run in ~5 minutes)

Unzip the repo, restore tools, apply migrations, and run the app:

```bash
# on Linux / macOS
./tools/build_and_run.sh

# on Windows (PowerShell)
.	oolsuild_and_run.ps1
```

Or run manual commands (also required by reviewers):

```bash
dotnet restore
dotnet ef database update --project src/ENSIT.MVVMApp.Infrastructure --startup-project src/ENSIT.MVVMApp
dotnet run --project src/ENSIT.MVVMApp
```

## Features
- Customer / Order simple domain with EF Core-backed persistence (SQLite file: `data/ensit.db`).
- Search/filter customers with async paging and cancellation.
- Edit customer and save with optimistic UI update.
- Logging via Serilog (console + file) and performance measurement of queries.
- Unit and integration tests using InMemory and SQLite providers.
- Performance examples of compiled queries and AsNoTracking.
- DI via Microsoft.Extensions.DependencyInjection and Host builder.

## Resume-ready single line
Designed and implemented a WPF (.NET 7) MVVM desktop application with Entity Framework Core (SQLite), DI, Serilog logging, async data access and performance optimizations — $[X%] average query time improvement using compiled queries & indices.

## Notes
- Replace `$[PLACEHOLDER]` and `$[X%]` tokens with project-specific values.
- Small screenshots are in `assets/`.
