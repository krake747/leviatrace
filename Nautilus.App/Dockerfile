FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Directory.Build.props", "./"]
COPY ["Directory.Packages.props", "./"]
COPY ["Nautilus.App/Nautilus.App.csproj", "Nautilus.App/"]
RUN dotnet restore "Nautilus.App/Nautilus.App.csproj"
COPY . .
WORKDIR "/src/Nautilus.App"
RUN dotnet publish "Nautilus.App.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Nautilus.App.dll"]
