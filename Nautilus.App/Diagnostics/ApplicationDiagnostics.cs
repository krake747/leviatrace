using System.Diagnostics;

namespace Nautilus.App.Diagnostics;

public static class ApplicationDiagnostics
{
    public const string ActivitySourceName = "Nautilus.App.Diagnostics";

    public static readonly ActivitySource ActivitySource = new(ActivitySourceName);
}
