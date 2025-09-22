#!/usr/bin/env pwsh
dotnet restore
if (-not (Get-Command dotnet-ef -ErrorAction SilentlyContinue)) {
  dotnet tool install --global dotnet-ef
}
dotnet ef database update --project src/ENSIT.MVVMApp.Infrastructure --startup-project src/ENSIT.MVVMApp
dotnet run --project src/ENSIT.MVVMApp
