using CleanArch.Domain.Entities;
using CleanArch.Domain.Structs;
using MediatR;

namespace CleanArch.Application.Members.Commands;
public sealed class DeleteMemberCommand : IRequest<Member>
{
    public CustomerId Id { get; set; }
}
