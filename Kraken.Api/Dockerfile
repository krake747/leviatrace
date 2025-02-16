FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Directory.Build.props", "./"]
COPY ["Directory.Packages.props", "./"]
COPY ["Kraken.Api/Kraken.Api.csproj", "Kraken.Api/"]
RUN dotnet restore "Kraken.Api/Kraken.Api.csproj"
COPY . .
WORKDIR "/src/Kraken.Api"
RUN dotnet publish "Kraken.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Kraken.Api.dll"]
