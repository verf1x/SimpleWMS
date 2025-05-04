namespace SimpleWMS.Domain.Entities;

public class User
{
    public Guid Id { get; set; }
    public required string UserName { get; set; }
    public required string PasswordHash { get; set; }
    public required string Role { get; set; } = "Worker";
}