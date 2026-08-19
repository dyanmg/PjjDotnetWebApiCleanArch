#!/usr/bin/env sh
export ASPNETCORE_ENVIRONMENT=Staging
# export DisableGlobalAuthorize=false
cd publish
dotnet ./PjjDotnetWebApiCleanArch.Api.dll
