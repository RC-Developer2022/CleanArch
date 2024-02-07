using CleanArch.Domain.Structs;

using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

public class CustomerIdConverter : ValueConverter<CustomerId, Guid>
{
    public CustomerIdConverter(ConverterMappingHints mappingHints = null)
        : base(
            id => id.value,
            value => new CustomerId(value),
            mappingHints)
    { }
    
}
