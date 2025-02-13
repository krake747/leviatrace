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

# Install .NET Auto Instrumentation
ARG OTEL_VERSION=1.10.0
RUN apt-get update && apt-get install -y unzip curl
ADD https://github.com/open-telemetry/opentelemetry-dotnet-instrumentation/releases/download/v${OTEL_VERSION}/otel-dotnet-auto-install.sh otel-dotnet-auto-install.sh
RUN apt-get update && apt-get install -y unzip && OTEL_DOTNET_AUTO_HOME="/otel-dotnet-auto" sh otel-dotnet-auto-install.sh
RUN chmod +x /otel-dotnet-auto/instrument.sh

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /
COPY --from=build /otel-dotnet-auto ./otel-dotnet-auto
WORKDIR /app
EXPOSE 8080
COPY --from=build /app/publish .
ENTRYPOINT ["/bin/bash", "-c", "source /otel-dotnet-auto/instrument.sh && dotnet Leviatrace.Api.dll"]
