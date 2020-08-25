FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src/Identity
COPY ["Identity.API/Identity.API.csproj", "Identity.API/Identity.API.csproj"]
COPY ["Identity.Infrastructure/Identity.Infrastructure.csproj", "Identity.Infrastructure/Identity.Infrastructure.csproj"]
RUN dotnet restore Identity.API/Identity.API.csproj
COPY . .

FROM build AS publish
RUN dotnet publish Identity.API/Identity.API.csproj -c Release -o /app/publish --no-restore

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Identity.API.dll"]
