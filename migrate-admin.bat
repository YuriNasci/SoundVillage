@echo off
set migrationName=%1
if "%migrationName%"=="" (
    echo Por favor, forneça um nome para a migração.
    exit /b
)

dotnet ef migrations add %migrationName% -c SoundVillageAdminContext -p ./SoundVillage.Repository -s ./SoundVillage.Admin -o AdminMigrations
dotnet ef database update -c SoundVillageAdminContext -p ./SoundVillage.Repository -s ./SoundVillage.Admin