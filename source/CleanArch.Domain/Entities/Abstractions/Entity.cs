namespace CleanArch.Domain.Entities.Abstractions;

public abstract class Entity
{
    public Guid Id { get; protected set; }

    public Entity()
    {
        Id = Guid.NewGuid();
    }
}
