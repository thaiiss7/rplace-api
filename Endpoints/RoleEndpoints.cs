using Rplace.UseCase.PromotePlayer;

namespace Rplace.Endpoints;

public static class RoleEndpoints
{
    public static void ConfigureRoleEndpoints(this WebApplication app)
    {
        app.MapPut("role", async (
            [FromBody] PromotePlayerPayload payload,
            [FromServices] PromotePlayerUseCase useCase) =>
            {
                var result = useCase.Do(payload);

                return (result.IsSuccess, result.Reason) switch
                {
                    (false, "Role not found") => Results.NotFound(),
                    (false, _) => Results.BadRequest(),
                    (true, _) => Results.Ok(result.Data)
                };
            });
    }
}
