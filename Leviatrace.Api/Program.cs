using Serilog;
using ILogger = Serilog.ILogger;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .CreateLogger()
    .ForContext<Program>();

builder.Host.UseSerilog(Log.Logger);

var app = builder.Build();

app.MapGet("/search-leviathan", (ILogger logger) =>
{
    // Simulate a deep dive ID, like encountering the Leviathan (simulates a trace id)
    var diveId = Random.Shared.Next(100000, 999999);

    logger.Information("An unseen force is diving into the depths, searching for Leviathan: Dive ID {DiveId}", diveId);

    return Results.Ok(new { DiveId = diveId });
});

app.Run();
