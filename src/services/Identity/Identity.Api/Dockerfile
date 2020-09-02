FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src/Identity
COPY ["Identity.Api/Identity.Api.csproj", "Identity.Api/Identity.Api.csproj"]
COPY ["Identity.Data/Identity.Data.csproj", "Identity.Data/Identity.Data.csproj"]
RUN dotnet restore Identity.Api/Identity.Api.csproj
COPY . .

FROM build AS publish
RUN dotnet publish Identity.Api/Identity.Api.csproj -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Identity.Api.dll"]
