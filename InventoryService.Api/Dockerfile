FROM mcr.microsoft.com/mssql/server:2022-latest

COPY Northwind.bak /var/opt/mssql/backup/
RUN /opt/mssql/bin/sqlservr & \
    sleep 10s && \
    /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P 1 -Q "RESTORE DATABASE Northwind FROM DISK='/var/opt/mssql/backup/Northwind.bak' WITH MOVE 'Northwind' TO '/var/opt/mssql/data/Northwind.mdf', MOVE 'Northwind_log' TO '/var/opt/mssql/data/Northwind_log.ldf', NOUNLOAD, REPLACE"

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["InventoryService.Api/NorthwindService.Api.csproj", "InventoryService.Api/"]
COPY ["InventoryService.Application/NorthwindService.Application.csproj", "InventoryService.Application/"]
COPY ["InventoryService.Domain/NorthwindService.Domain.csproj", "InventoryService.Domain/"]
COPY ["InventoryService.Infrastructure/NorthwindService.Infrastructure.csproj", "InventoryService.Infrastructure/"]
RUN dotnet restore "./InventoryService.Api/./NorthwindService.Api.csproj"
COPY . .
WORKDIR "/src/InventoryService.Api"
RUN dotnet build "./NorthwindService.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./NorthwindService.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NorthwindService.Api.dll"]
