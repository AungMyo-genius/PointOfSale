namespace PointOfSale.App.Models;

public sealed record ReportDefinition(
    string Category,
    string Name,
    string Purpose,
    string KeyMetrics,
    string Frequency);
