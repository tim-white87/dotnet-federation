FROM mcr.microsoft.com/dotnet/core/sdk:3.1-alpine
RUN apk add make
ENV PATH $PATH:/root/.dotnet/tools
RUN dotnet tool install -g dotnet-ef
WORKDIR /src/Identity/Identity.Data
COPY . .
ENTRYPOINT [ "make" ]
CMD [ "up" ]