using Rplace.UseCase.AcceptInvite;
using Rplace.UseCase.GetInvite;
using Rplace.UseCase.InvitePlayer;

namespace Rplace.Endpoints;

public static class InviteEndpoints
{
    public static void ConfigureInviteEndpoints(this WebApplication app)
    {
        //AcceptInvite
        app.MapPost("/accept", async (
            [FromBody] AcceptinvitePayload payload,
            [FromServices] AccepteInviteUseCase useCase) =>
            {
                var result = await useCase.Do(payload);

                return (result.IsSuccess, result.Reason) switch
                {
                    (false, "Pin not found") => Results.NotFound(),
                    (false, _) => Results.BadRequest(),
                    (true, _) => Results.Ok(result.Data)
                };
            });

        //InvitePlayer
        app.MapPost("invite", async (
            [FromBody] InvitePlayerPayload payload,
            [FromServices] InvitePlayerUseCase useCase) =>
            {
                var result = await InvitePlayerUseCase.Do(payload);

                if (result.IsSuccess)
                    return Results.Created();

                return Results.BadRequest(result.Reason);
            });

        //GetInvite
        app.MapGet("invite/{id}", async (
            Guid id,
            [FromServices] GetInviteUseCase useCase) =>
            {
                var claim = http.User.FindFirst(ClaimTypes.NameIdentifier);
                var userId = Guid.Parse(claim.Value);
                var pinId = Guid.Parse(id);
                var payload = new GetInvitePayload(id, userId);
                var result = await useCase.Do(payload);

                return (result.IsSuccess, result.Reason) switch
                {
                    (false, "User not found") => Results.NotFound(),
                    (false, _) => Results.BadRequest(),
                    (true, _) => Results.Ok(result.Data)
                };
            }).RequireAuthorization();
    }
}