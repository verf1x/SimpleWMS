namespace SimpleWMS.Api.Models;

public class CreateCrateRequest
{
    /// <summary>
    /// Код ящика в формате L-AA-BB_CC (L = A–I, AA = 1–6, BB = 1–3, CC = 1–3).
    /// </summary>
    /// <example>A-02-1_03</example>
    public string LocationCode { get; set; } = string.Empty;
}