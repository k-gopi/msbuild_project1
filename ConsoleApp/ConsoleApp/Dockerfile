# Base runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

# Build image with SDK
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# Copy the .csproj file relative to the context
COPY ["ConsoleApp.csproj", "./"]
RUN dotnet restore "./ConsoleApp.csproj"

# Copy all files to build context and build
COPY . .
RUN dotnet build "./ConsoleApp.csproj" -c Release -o /app/build

# Publish app
FROM build AS publish
RUN dotnet publish "./ConsoleApp.csproj" -c Release -o /app/publish

# Final runtime image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ConsoleApp.dll"]
