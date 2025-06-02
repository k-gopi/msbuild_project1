# Base image for running the app
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

# SDK image for build
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# Correct .csproj path
COPY ["ConsoleApp.csproj", "./"]
RUN dotnet restore "./ConsoleApp.csproj"

COPY . .
RUN dotnet build "./ConsoleApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "./ConsoleApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ConsoleApp.dll"]
