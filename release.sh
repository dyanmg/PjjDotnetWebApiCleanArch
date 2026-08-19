#!/usr/bin/env sh
# rm -rf publish
dotnet build -c Release src/PjjDotnetWebApiCleanArch.Api
dotnet publish -c Release -o publish src/PjjDotnetWebApiCleanArch.Api
dotnet ef migrations bundle --self-contained -o ./publish/efbundle --project src/PjjDotnetWebApiCleanArch.Api --configuration Release --verbose
