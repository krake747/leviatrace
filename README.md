# Leviatrace 🐋

Leviatrace is a hands-on observability playground using OpenTelemetry, the LGTM stack (Loki, Grafana, Tempo), and .NET
services.

I'm building Leviatrace to explore and learn OpenTelemetry by integrating it with the LGTM stack and .NET services in a
hands-on environment.

## Setup

Navigate to the root directory which contains the `compose.yaml` file and run:

```shell
docker compose up -d
```

Use the `leviatrace.http` file and select the `docker` environment to send requests.

## Leviathan API

It is a service to search for Leviathan by sending `diveIds`.

The project contains a DockerFile setup that adds .NET auto-instrumentation for monitoring.

I use Jaeger UI and trace integration to visualize the traces.

[Zero-code Instrumentation - Getting Started](https://opentelemetry.io/docs/zero-code/net/getting-started/)
