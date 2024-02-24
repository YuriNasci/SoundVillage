@echo off
set migrationName=%1
if "%migrationName%"=="" (
    echo Por favor, forneça um nome para a migração.
    exit /b
)
dotnet ef migrations add %migrationName% -c SoundVillageContext -p ./SoundVillage.Repository/SoundVillage.Repository.csproj -s ./SoundVillage.Api/SoundVillage.Api.csproj
dotnet ef database update -p ./SoundVillage.Repository/SoundVillage.Repository.csproj -s ./SoundVillage.Api/SoundVillage.Api.csproj