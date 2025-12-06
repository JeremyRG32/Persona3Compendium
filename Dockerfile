# ============================
# 1. Build Stage
# ============================
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy project file
COPY ./Persona3Compendium.Web/Persona3Compendium.Web.csproj ./Persona3Compendium.Web/
RUN dotnet restore ./Persona3Compendium.Web/Persona3Compendium.Web.csproj

# Copy everything
COPY . .

# Publish
RUN dotnet publish ./Persona3Compendium.Web/Persona3Compendium.Web.csproj -c Release -o /app


# ============================
# 2. Runtime Stage
# ============================
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

COPY --from=build /app .

ENV ASPNETCORE_URLS=http://0.0.0.0:10000
EXPOSE 10000

CMD ["dotnet", "Persona3Compendium.Web.dll"]
