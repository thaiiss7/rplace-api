using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Rplace.Data;
using Rplace.UseCase.AcceptInvite;
using Rplace.UseCase.GetInvite;
using Rplace.UseCase.InvitePlayer;

namespace Rplace.Endpoints;

public static class InviteEndpoints
{
    public static void ConfigureInviteEndpoints(this WebApplication app)
    {
        // aceitar um convite
        app.MapPut("invite/accept", async (
            HttpContext http,
            [FromBody] AcceptInviteData payload,
            [FromServices] AcceptInviteUseCase useCase) =>
            {
                var claim = http.User.FindFirst(ClaimTypes.NameIdentifier);
                if (claim is null)
                    return Results.Unauthorized();
                var id = Guid.Parse(claim.Value);

                var result = await useCase.Do(new AcceptInvitePayload(
                    payload.Accept,
                    payload.InviteId,
                    id
                ));

                return (result.IsSuccess, result.Reason) switch
                {
                    (false, "Invite not found") => Results.NotFound(),
                    (false, _) => Results.BadRequest(),
                    (true, _) => Results.Ok(result.Data)
                };
            });

        // fazer um convite
        app.MapPost("invite", async (
            [FromBody] InvitePlayerPayload payload,
            [FromServices] InvitePlayerUseCase useCase) =>
            {
                var result = await useCase.Do(payload);

                if (result.IsSuccess)
                    return Results.Created();

                return Results.BadRequest(result.Reason);
            });

        // listar convites de um usuário
        app.MapGet("invite/{userId}", async (
            Guid userId,
            [FromServices] GetInviteUseCase useCase) =>
            {
                var payload = new GetInvitePayload(userId);
                var result = await useCase.Do(payload);

                return (result.IsSuccess, result.Reason) switch
                {
                    (false, "Invite not found") => Results.NotFound(),
                    (false, _) => Results.BadRequest(),
                    (true, _) => Results.Ok(result.Data)
                };
            });
    }
}