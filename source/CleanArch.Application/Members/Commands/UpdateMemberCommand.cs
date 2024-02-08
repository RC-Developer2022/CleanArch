using CleanArch.Domain.Entities;
using CleanArch.Domain.Structs;

using MediatR;

namespace CleanArch.Application.Members.Commands;
public sealed class UpdateMemberCommand : IRequest<Member>
{
    public CustomerId Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Gender { get; set; }
    public string? Email { get; set; }
    public bool? IsActive { get; set; }
}
