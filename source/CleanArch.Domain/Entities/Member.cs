using CleanArch.Domain.Entities.Abstractions;
using CleanArch.Domain.Validations;

namespace CleanArch.Domain.Entities;

public sealed class Member : Entity
{
    public string? FirstName { get; private set; }
    public string? LastName { get; private set; }
    public string? Gender { get; private set; }
    public string? Email { get; private set; }
    public bool? IsActive { get; private set; }

    public Member(string firstName, string lastName, string gender, string email, bool isActive)
    {
        ValidateDomain(firstName, lastName, gender, email, isActive);
    }

    private void ValidateDomain(string firstName, string lastName, string gender, string email, bool isActive) 
    {
        DomainValidation.When(string.IsNullOrEmpty(firstName), "Invalid name. FirstName is required!");
d    }
}
