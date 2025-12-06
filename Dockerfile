FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY Persona3Compendium.Web/Persona3Compendium.Web.csproj Persona3Compendium.Web/
RUN dotnet restore Persona3Compendium.Web/Persona3Compendium.Web.csproj

COPY . .

WORKDIR /src/Persona3Compendium.Web
RUN dotnet publish -c Release -o /app/publish

FROM base AS final
WORKDIR /app

COPY --from=build /app/publish .

COPY Persona3Compendium.Web/Persona.db /app/Persona.db

ENV ASPNETCORE_URLS=http://0.0.0.0:${PORT}

ENTRYPOINT ["dotnet", "Persona3Compendium.Web.dll"]
