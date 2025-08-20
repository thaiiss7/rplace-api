using Microsoft.AspNetCore.Mvc;
using Rplace.UseCase.CreateRoom;
using Rplace.UseCase.GetRoom;

namespace Rplace.Endpoints;

public static class RoomEndpoints
{
    public static void ConfigureRoomEndpoints(this WebApplication app)
    {
        // acessar uma sala
        app.MapGet("room/{name}", async (
            string name,
            [FromServices] GetRoomUseCase useCase) =>
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

        // criar uma sala
        app.MapPost("room", async (
            [FromBody] CreateRoomPayload payload,
            [FromServices] CreateRoomUseCase useCase) =>
            {
                var result = await useCase.Do(payload);

                if (result.IsSuccess)
                    return Results.Created();

                return Results.BadRequest(result.Reason);
            });
    }
}