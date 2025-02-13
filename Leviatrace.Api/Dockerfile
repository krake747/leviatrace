FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Directory.Build.props", "./"]
COPY ["Directory.Packages.props", "./"]
COPY ["Leviatrace.Api/Leviatrace.Api.csproj", "Leviatrace.Api/"]
RUN dotnet restore "Leviatrace.Api/Leviatrace.Api.csproj"
COPY . .
WORKDIR "/src/Leviatrace.Api"
RUN dotnet publish "Leviatrace.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 6000
EXPOSE 6001
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Leviatrace.Api.dll"]
