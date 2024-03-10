REM Como usar: migrate.bat "Nome da sua Migration"
@echo off
setlocal enabledelayedexpansion
set "migrationName="
:loop
if "%~1"=="" goto :run
set "migrationName=!migrationName! %1"
shift
goto :loop
:run

if "%migrationName%"=="" (
    echo Por favor, forneça um nome para a migração.
    exit /b
)
dotnet ef migrations add "%migrationName:~1%" --startup-project SeuProjeto.csproj --project SuaProjetoDeDados.csproj
dotnet ef database update --startup-project SeuProjeto.csproj --project SuaProjetoDeDados.csproj
