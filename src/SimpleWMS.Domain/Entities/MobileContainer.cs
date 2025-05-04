using SimpleWMS.Domain.ValueObjects;

namespace SimpleWMS.Domain.Entities;

public class MobileContainer
{
    public Guid Id { get; set; }
    public MobileContainerNumber Number { get; private set; }
    public bool IsClosed { get; private set; }

    private MobileContainer() { }

    public MobileContainer(string number)
    {
        Number = MobileContainerNumber.Parse(number);
        IsClosed = false;
    }

    public void Close() => IsClosed = true;
}