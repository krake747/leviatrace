using Nautilus.App.Diagnostics;
using OpenTelemetry;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

using var traceProvider = Sdk.CreateTracerProviderBuilder()
    .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService("Nautilus.App"))
    .AddSource(ApplicationDiagnostics.ActivitySourceName)
    .AddConsoleExporter()
    .Build();

await TrackDive();

Console.WriteLine("Dive Completed!");

return;

static async Task TrackDive()
{
    using var activity = ApplicationDiagnostics.ActivitySource.StartActivity(nameof(TrackDive));
    await BeginDescent();
    await ExploreDepths();
}

static async Task BeginDescent() => await Task.Delay(500);
static async Task ExploreDepths() => await Task.Delay(1000);
