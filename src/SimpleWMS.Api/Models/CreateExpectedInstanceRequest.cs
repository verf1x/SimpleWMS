namespace SimpleWMS.Api.Models;

public class CreateExpectedInstanceRequest
{
    /// <example>SHIP-001234-0001</example>
    public string ShippingNumber { get; set; } = string.Empty;

    /// <example>Sort</example>
    public string SortType { get; set; } = string.Empty;   // "Sort" | "Nonsort"
}