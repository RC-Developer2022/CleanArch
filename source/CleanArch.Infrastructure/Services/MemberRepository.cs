using CleanArch.Domain.Abstractions;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Structs;
using CleanArch.Infrastructure.Context;

using Microsoft.EntityFrameworkCore;

namespace CleanArch.Infrastructure.Services;
public class MemberRepository(AppDbContext context) : IMemberRepository
{
    public async Task<Member> GetMemberById(CustomerId id)
    {
        var member = await context.Members.FindAsync(id);

        if (member is null)
            throw new InvalidOperationException("Member not found");

        return member;
    }

    public async Task<IEnumerable<Member>> GetMembers()
    {
        var memberlist = await context.Members.ToListAsync();
        return memberlist ?? Enumerable.Empty<Member>();
    }

    public async Task<Member> AddMember(Member member)
    {
        if (member is null)
            throw new ArgumentNullException(nameof(member));

        await context.Members.AddAsync(member);
        return member;
    }

    public void UpdateMember(Member member)
    {
        if (member is null)
            throw new ArgumentNullException(nameof(member));

        context.Members.Update(member);
    }

    public async Task<Member> DeleteMember(CustomerId memberId)
    {
        var member = await GetMemberById(memberId);

        if (member is null)
            throw new InvalidOperationException("Member not found");

        context.Members.Remove(member);
        return member;
    }
}
