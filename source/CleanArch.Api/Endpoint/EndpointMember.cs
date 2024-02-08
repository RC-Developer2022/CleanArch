using CleanArch.Application.Members.Commands;
using CleanArch.Domain.Abstractions;
using CleanArch.Domain.Structs;

using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace CleanArch.Api.Endpoint;

public static class EndpointMember
{
    public static void MapMember(this WebApplication app) 
    {
        var group = app.MapGroup("/member");
        group.MapGet("/{id}", GetMember).WithName(nameof(GetMember)).WithOpenApi();
        group.MapPost("/", CreateMember).WithName(nameof(CreateMember)).WithOpenApi();
        group.MapPut("/{id}", UpdateMember).WithName(nameof(UpdateMember)).WithOpenApi();
        group.MapDelete("/{id}", DeleteMember).WithName(nameof(DeleteMember)).WithOpenApi();
    }

    public static async Task<IResult> GetMember(IUnitOfWork unitOfWork, CustomerId id)
    {
        var member = await unitOfWork.MemberRepository.GetMemberById(id);
        return member != null ? Results.Ok(member) : Results.NotFound("Member not found.");
    }

    public static async Task<IResult> CreateMember ([FromServices] IMediator mediator, [FromBody] CreateMamberCommand command) 
    {
        var createdMember = await mediator.Send(command);
        return Results.Created("Created:", createdMember);
    }

    public static async Task<IResult> UpdateMember(IMediator mediator, CustomerId id, UpdateMemberCommand command)
    {
        command.Id = id;
        var updatedMember = await mediator.Send(command);

        return updatedMember != null ? Results.Ok(updatedMember) : Results.NotFound("Member not found.");
    }

    public static async Task<IResult> DeleteMember(IMediator mediator, CustomerId id)
    {
        var command = new DeleteMemberCommand { Id = id };
        var deletedMember = await mediator.Send(command);

        return deletedMember != null ? Results.Ok(deletedMember) : Results.NotFound("Member not found.");
    }
}
