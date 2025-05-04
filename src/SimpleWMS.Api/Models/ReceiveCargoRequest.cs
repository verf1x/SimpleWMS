namespace SimpleWMS.Api.Models
{
    public class ReceiveCargoRequest
    {
        /// <example>CARGO-001</example>
        public string CargoBarcode { get; set; } = string.Empty;
    }
}