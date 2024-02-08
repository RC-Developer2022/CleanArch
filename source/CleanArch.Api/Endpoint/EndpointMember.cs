using CleanArch.Application.Members.Commands;
using CleanArch.Domain.Abstractions;
using CleanArch.Domain.Structs;
using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace CleanArch.Api.Endpoint
{
    public static class EndpointMember
    {
        public static void MapMember(this WebApplication app)
        {
            var group = app.MapGroup("/member");
            group.MapGet("/Get{id}", GetMember).WithName(nameof(GetMember)).WithOpenApi();
            group.MapPost("/Post", CreateMember).WithName(nameof(CreateMember)).WithOpenApi();
            group.MapPut("/Put{id}", UpdateMember).WithName(nameof(UpdateMember)).WithOpenApi();
            group.MapDelete("/Delete{id}", DeleteMember).WithName(nameof(DeleteMember)).WithOpenApi();
        }

        public static async Task<IResult> GetMember([FromServices] IUnitOfWork unitOfWork, [FromHeader] string id)
        {
            if (CustomerId.TryParse(id, out var customerId))
            {
                var member = await unitOfWork.MemberRepository.GetMemberById(customerId);
                return member != null ? Results.Ok(member) : Results.NotFound("Member not found.");
            }
            else
            {
                return Results.BadRequest("Invalid Customer ID format");
            }
        }

        public static async Task<IResult> CreateMember([FromServices] IMediator mediator, [FromBody] CreateMamberCommand command)
        {
            var createdMember = await mediator.Send(command);
            return Results.Created("Created:", createdMember);
        }

        public static async Task<IResult> UpdateMember([FromServices] IMediator mediator, [FromHeader] string id, [FromBody] UpdateMemberCommand command)
        {
            if (CustomerId.TryParse(id, out var customerId))
            {
                command.Id = customerId;
                var updatedMember = await mediator.Send(command);

                return updatedMember != null ? Results.Ok(updatedMember) : Results.NotFound("Member not found.");
            }
            else
            {
                return Results.BadRequest("Invalid Customer ID format");
            }
        }

        public static async Task<IResult> DeleteMember([FromServices] IMediator mediator, [FromHeader] string id)
        {
            if (CustomerId.TryParse(id, out var customerId))
            {
                var command = new DeleteMemberCommand { Id = customerId };
                var deletedMember = await mediator.Send(command);

                return deletedMember != null ? Results.Ok(deletedMember) : Results.NotFound("Member not found.");
            }
            else
            {
                return Results.BadRequest("Invalid Customer ID format");
            }
        }
    }
}
