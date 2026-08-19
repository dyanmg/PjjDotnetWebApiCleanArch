#!/usr/bin/env sh
# rm -rf publish
dotnet build -c Release src/PjjDotnetWebApiCleanArch.Api
dotnet publish -c Release -o publish src/PjjDotnetWebApiCleanArch.Api
# dotnet ef migrations bundle --self-contained -o ./publish/efbundle --project src/PjjDotnetWebApiCleanArch.Api --configuration Release --verbose
dotnet ef migrations script --project src/PjjDotnetWebApiCleanArch.Infrastructure --output ./publish/migrations.sql --configuration Release --startup-project src/PjjDotnetWebApiCleanArch.Api --verbose --from AddNikNpwpColumn
