# Case study (1 page)

Problem: teachable demo app showing modern .NET desktop architecture with emphasis on data access performance.

Approach: WPF + MVVM, EF Core for persistence, DI/Host pattern, Serilog for logging. Implemented async search with cancellation, compiled queries and indexes. Seeded demo dataset for repeatable perf runs.

Key decisions: use SQLite for friction-free demo; wrap EF access in IDataService; measure times and log them.

Performance: sample compiled queries and AsNoTracking usage — measured improvements $[X%] (replace with real numbers after benchmarking).

Next steps: add paging server-side, optimistic concurrency control, and richer UI/UX polish.
