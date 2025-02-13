using OpenTelemetry.Logs;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using Serilog;
using ILogger = Serilog.ILogger;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .CreateLogger()
    .ForContext<Program>();

builder.Host.UseSerilog(Log.Logger);

builder.Services.AddOpenTelemetry()
    .ConfigureResource(resource => resource.AddService("Leviatrace.Api"))
    .WithTracing(static tracing =>
        tracing
            .AddAspNetCoreInstrumentation()
            .AddHttpClientInstrumentation()
            .AddOtlpExporter()
    )
    .WithMetrics(static metrics =>
        metrics
            .AddAspNetCoreInstrumentation()
            .AddHttpClientInstrumentation()
            .AddOtlpExporter()
    )
    .WithLogging(static logging =>
        logging
            .AddConsoleExporter()
            .AddOtlpExporter()
    );

var app = builder.Build();

app.MapGet("/", () => Results.Ok("Leviatrace.Api"));

app.MapGet("/search-leviathan", (ILogger logger) =>
{
    // Simulate a deep dive ID, like encountering the Leviathan (simulates a trace id)
    var diveId = Random.Shared.Next(100000, 999999);

    logger.Information("An unseen force is diving into the depths, searching for Leviathan: Dive ID {DiveId}", diveId);

    return Results.Ok(new { DiveId = diveId });
});

app.Run();
