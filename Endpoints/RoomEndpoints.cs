using Rplace.UseCase.GetInvite;
using Rplace.UseCase.GetPlayer;

namespace Rplace.Endpoints;

public static class RoomEndpoints
{
    public static void ConfigureRoomEndpoints(this WebApplication app)
    {
        // acessar uma sala
        app.MapGet("room/{name}", async (
            string name,
            [FromServices]GetRoomUseCase useCase) =>
            {
                var payload = new GetRoomPayload(name);
                var result = await useCase.Do(payload);

                return (result.IsSuccess, result.Reason) switch
                {
                    (false, "Room not found") => Results.NotFound(),
                    (false, _) => Results.BadRequest(),
                    (true, _) => Results.Ok(result.Data)
                };
            });

        // acessar membros em uma sala (GetPlayer)
        app.MapGet("member/{room}/{userId}", async (
            Guid roomId,
            Guid userId,
            [FromServices] GetPlayerUseCase useCase) =>
            {
                var payload = GetPlayerPayload(roomId, userId);
                var result = useCase.Do(payload);

                return (result.IsSuccess, result.Reason) switch
                {
                    (false, "Room or User not found") => Results.NotFound(),
                    (false, _) => Results.BadRequest(),
                    (true, _) => Results.Ok(result.Data)
                };

            });

        // criar uma sala
        app.MapPost("room", async (
            [FromBody]CreateRoomPayload payload,
            [FromServices]CreateRoomUseCase useCase) =>
            {
                var result = await useCase.Do(payload);
            
                if (result.IsSuccess)
                return Results.Created();
            
                return Results.BadRequest(result.Reason);
            });
    }
}