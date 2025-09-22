#!/usr/bin/env bash
set -e
echo 'Restoring...'
dotnet restore
echo 'Applying EF migrations (ensure dotnet-ef is installed)'
if ! dotnet ef --version >/dev/null 2>&1; then
  echo 'dotnet-ef not found. Installing as local tool...'
  dotnet tool install --global dotnet-ef || true
fi
echo 'Updating database...'
dotnet ef database update --project src/ENSIT.MVVMApp.Infrastructure --startup-project src/ENSIT.MVVMApp || true
echo 'Building and running app (WPF will only open on Windows)...'
dotnet run --project src/ENSIT.MVVMApp
