FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["src/messages/Messages.csproj", "src/messages/"]
RUN dotnet restore "src/messages/Messages.csproj"
COPY . .
WORKDIR "/src/src/messages"
RUN dotnet build "Messages.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Messages.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Messages.dll"]
