# Build stage
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build

WORKDIR /src

# Copy project files
COPY ["src/RaqNRollPlayground.WebApi/RaqNRollPlayground.WebApi.csproj", "src/RaqNRollPlayground.WebApi/"]
COPY ["src/RaqNRollPlayground.Infra/RaqNRollPlayground.Infra.csproj", "src/RaqNRollPlayground.Infra/"]
COPY ["src/ReqNRollPlayground.Domain/ReqNRollPlayground.Domain.csproj", "src/ReqNRollPlayground.Domain/"]

# Restore dependencies
RUN dotnet restore "src/RaqNRollPlayground.WebApi/RaqNRollPlayground.WebApi.csproj"

# Copy all source code
COPY ["src/", "src/"]

# Publish the project
RUN dotnet publish "src/RaqNRollPlayground.WebApi/RaqNRollPlayground.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:10.0

WORKDIR /app

# Copy published files from build stage
COPY --from=build /app/publish .

EXPOSE 8080
EXPOSE 8443

ENTRYPOINT ["dotnet", "RaqNRollPlayground.WebApi.dll"]

