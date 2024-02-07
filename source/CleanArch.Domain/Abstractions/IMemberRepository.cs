using CleanArch.Domain.Entities;
using CleanArch.Domain.Structs;

namespace CleanArch.Domain.Abstractions;
public interface IMemberRepository
{
    Task<IEnumerable<Member>> GetMembers();
    Task<Member> GetMemberById(CustomerId memberId);
    Task<Member> AddMember(Member member);
    void UpdateMember(Member member);
    Task<Member> DeleteMember(CustomerId memberId);
}
