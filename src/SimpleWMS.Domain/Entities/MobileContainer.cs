using SimpleWMS.Domain.ValueObjects;

namespace SimpleWMS.Domain.Entities;

public class MobileContainer
{
    public Guid Id { get; set; }
    public MobileContainerNumber Number { get; set; }
    public bool IsClosed { get; private set; }

    public MobileContainer() { }

    public MobileContainer(string number)
    {
        Number = MobileContainerNumber.Parse(number);
        IsClosed = false;
    }

    public void Close() => IsClosed = true;
}