# ============================
# 1. Build Stage
# ============================
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy csproj and restore dependencies
COPY *.csproj ./
RUN dotnet restore

# Copy the rest of the project
COPY . ./

# Publish the project
RUN dotnet publish -c Release -o /app


# ============================
# 2. Runtime Stage
# ============================
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Copy published app
COPY --from=build /app .

# Render requires the server to listen on 0.0.0.0 and its PORT variable
ENV ASPNETCORE_URLS=http://0.0.0.0:10000

# Expose Render port
EXPOSE 10000

# Run your ASP.NET Core app
CMD ["dotnet", "Persona3Compendium.Web.dll"]
