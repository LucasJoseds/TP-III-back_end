# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src
COPY ["pedidos_back_end.csproj", "./"]
RUN dotnet restore

COPY . .
RUN dotnet build -c Release -o /app/build


# Publish stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/build .


# Command to start the application
ENTRYPOINT ["dotnet", "pedidos_back_end.dll"]