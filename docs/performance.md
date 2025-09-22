# Performance

Techniques used:
- AsNoTracking() for read-only queries
- EF.CompileQuery for hot paths
- Indexes declared in OnModelCreating
- Timing via Stopwatch and Serilog logs
- Recommendations: use batching, avoid heavy client evaluation, profile with dotnet-trace/dotnet-counters
