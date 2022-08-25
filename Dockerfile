FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

COPY Lapka.ApiGateway/Lapka.ApiGateway.csproj Lapka.ApiGateway/Lapka.ApiGateway.csproj
RUN dotnet restore Lapka.ApiGateway

COPY . .
RUN dotnet publish Lapka.ApiGateway -c release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app/out .

ARG BUILD_VERSION
ENV BUILD_VERSION $BUILD_VERSION

ENTRYPOINT ["dotnet", "Lapka.ApiGateway.dll"]