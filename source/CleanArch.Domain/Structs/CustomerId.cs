using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArch.Domain.Structs;


public readonly record struct CustomerId(Guid value)
{
    public static CustomerId Empty => new(Guid.Empty);
    public static CustomerId NewGuidCustomerId() => new(Guid.NewGuid());

    public static bool TryParse(string s, out CustomerId result)
    {
        if (Guid.TryParse(s, out var guidResult))
        {
            result = new CustomerId(guidResult);
            return true;
        }

        result = Empty;
        return false;
    }
}
