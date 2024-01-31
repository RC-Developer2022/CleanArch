namespace CleanArch.Domain.Structs;

public readonly record struct CustomerId(Guid value)
{
    public static CustomerId Empty => new(Guid.Empty);
    public static CustomerId NewGuidCustomerId() => new(Guid.NewGuid());
}
