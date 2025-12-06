# ASP.NET Core Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

# Build Stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy csproj and restore
COPY Persona3Compendium.Web/Persona3Compendium.Web.csproj Persona3Compendium.Web/
RUN dotnet restore Persona3Compendium.Web/Persona3Compendium.Web.csproj

# Copy everything else
COPY . .

# Publish
WORKDIR /src/Persona3Compendium.Web
RUN dotnet publish -c Release -o /app/publish

# Runtime Image
FROM base AS final
WORKDIR /app

# Copy published output
COPY --from=build /app/publish .

# ⬅️ IMPORTANT: copy SQLite DB into container
COPY Persona3Compendium.Web/Persona.db /app/Persona.db

ENTRYPOINT ["dotnet", "Persona3Compendium.Web.dll"]
