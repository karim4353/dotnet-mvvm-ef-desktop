# Architecture

This sample follows MVVM:
- Views: WPF XAML files in Views/
- ViewModels: presentation logic, ICommand implementations
- Models: domain objects mapped to EF Core entities
- Services: IDataService/EfDataService encapsulate data access and measure performance
- Infrastructure: ENSITContext (DbContext), DI registration, DataSeeder

Dependency Injection uses Microsoft.Extensions.Hosting and registers DbContext, IDataService, and repositories in DiExtensions.
