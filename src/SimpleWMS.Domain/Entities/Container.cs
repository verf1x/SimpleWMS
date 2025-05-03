namespace SimpleWMS.Domain.Entities;

public class Container
{
    private readonly List<Instance> _instances = [];

    public Guid Id { get; private set; } = Guid.NewGuid();

    public string ContainerBarcode { get; private set; } = string.Empty;

    public string CargoName { get; private set; } = string.Empty;

    public ContainerStatus Status { get; private set; } = ContainerStatus.Forming;

    public IReadOnlyCollection<Instance> Instances => _instances;

    private Container()
    {
    }

    public static Container Create(string containerBarcode, string cargoName)
    {
        return new()
        {
            ContainerBarcode = containerBarcode,
            CargoName = cargoName
        };
    }
}

public enum ContainerStatus
{
    Forming,
    Assembled
}