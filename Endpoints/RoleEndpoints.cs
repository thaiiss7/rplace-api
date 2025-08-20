using Rplace.UseCase.PromotePlayer;

namespace Rplace.Endpoints;

public static class RoleEndpoints
{
    public static void ConfigureRoleEndpoints(this WebApplication app)
    {
        app.MapPost("/promote{roomId}/{userId}", async (
            Guid roomId,
            Guid userId,
            [FromServices] PromotePlayerUseCase useCase) =>
            {
                var payload = new PromotePlayerPayload(roomId, userId);
                var result = useCase.Do(payload);

                return (result.IsSuccess, result.Reason) switch
                {
                    (false, "Player not found") => Results.NotFound(),
                    (false, _) => Results.BadRequest(),
                    (true, _) => Results.Ok(result.Data)
                };
            });
    }
}