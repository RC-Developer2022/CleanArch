using CleanArch.Domain.Structs;

namespace CleanArch.Domain.Entities.Abstractions;

public abstract class Entity
{
    public CustomerId Id { get; protected set; } = CustomerId.Empty;

    public Entity()
    {
        Id = CustomerId.NewGuidCustomerId();
    }
}
