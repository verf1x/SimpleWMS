namespace SimpleWMS.Api.Models.Labels.ShippingDependencies;

/// <summary>
/// Маршрут перевозки: от пункта A до пункта B.
/// </summary>
public class TransportationRoute
{
    public string Origin { get; set; } = string.Empty;
    
    public string Destination { get; set; } = string.Empty;
}