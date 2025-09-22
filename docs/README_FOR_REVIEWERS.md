# Quick verification script for reviewers

1. Unzip and cd into the repo
2. Run: ./tools/build_and_run.sh (or tools/build_and_run.ps1 on Windows)
3. Run tests: dotnet test src/ENSIT.MVVMApp.Tests
4. Verify app UI shows list of customers; try search and edit a row.
5. Run perf: dotnet run --project src/ENSIT.MVVMApp.Perf
