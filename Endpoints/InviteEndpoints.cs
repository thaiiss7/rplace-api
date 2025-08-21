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
            [FromBody] AcceptinvitePayload payload,
            [FromServices] AccepteInviteUseCase useCase) =>
            {
                var result = await useCase.Do(payload);

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
                var result = await InvitePlayerUseCase.Do(payload);

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