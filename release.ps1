Remove-Item -Recurse -Force publish
dotnet build -c Release PjjDotnetWebApiCleanArch.Api
dotnet publish -c Release -o publish PjjDotnetWebApiCleanArch.Api
