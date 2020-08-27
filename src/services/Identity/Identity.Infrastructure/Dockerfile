FROM mcr.microsoft.com/dotnet/core/sdk:3.1-alpine
ENV PATH $PATH:/root/.dotnet/tools
RUN dotnet tool install -g dotnet-ef
WORKDIR /src/Identity/Identity.Infrastructure
COPY . .
ENTRYPOINT [ "dotnet-ef" ]
CMD [ "database", "update" ]