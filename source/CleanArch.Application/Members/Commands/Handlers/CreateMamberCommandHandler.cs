using CleanArch.Domain.Abstractions;
using CleanArch.Domain.Entities;

using MediatR;

namespace CleanArch.Application.Members.Commands.Handlers;
public class CreateMamberCommandHandler : IRequestHandler<CreateMamberCommand, Member>
{
    private readonly IUnitOfWork unitOfWork;
    public CreateMamberCommandHandler(IUnitOfWork _unitOfWork)
    {
        unitOfWork = _unitOfWork;
    }
    public async Task<Member> Handle(CreateMamberCommand request, CancellationToken cancellationToken)
    {
        var newMember = new Member(request.FirstName, request.LastName, request.Gender, request.Email, request.IsActive ?? false);

        await unitOfWork.MemberRepository.AddMember(newMember);
        await unitOfWork.CommitAsync();

        return newMember;
    }
}
