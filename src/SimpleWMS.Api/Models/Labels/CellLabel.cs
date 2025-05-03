namespace SimpleWMS.Api.Models.Labels;

#nullable disable

/// <summary>
/// Управляющая этикетка ячейки
/// </summary>
public class CellLabel
{
    public string CellNumber { get; set; } = string.Empty;
    public string TargetDestination { get; set; } = string.Empty;
    public QRCode QRCode { get; set; }
}