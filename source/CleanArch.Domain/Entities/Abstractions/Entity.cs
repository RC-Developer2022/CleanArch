using System.ComponentModel.DataAnnotations.Schema;

using CleanArch.Domain.Structs;

namespace CleanArch.Domain.Entities.Abstractions;

public abstract class Entity
{
    public CustomerId Id { get; set; } = CustomerId.Empty;

    public Entity()
    {
        Id = CustomerId.NewGuidCustomerId();
    }
}
