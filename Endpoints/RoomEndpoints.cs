using Microsoft.AspNetCore.Mvc;
using Rplace.UseCase.CreateRoom;
using Rplace.UseCase.GetRoom;
using Rplace.UseCase.GetPlayer;
using Rplace.UseCase.RemovePlayer;

namespace Rplace.Endpoints;

public static class RoomEndpoints
{
    public static void ConfigureRoomEndpoints(this WebApplication app)
    {
        // acessar sala
        app.MapGet("room/{id}", async (
            Guid id,
            [FromServices] GetRoomUseCase useCase) =>
            {
                var payload = new GetRoomPayload(id);
                var result = await useCase.Do(payload);

                return (result.IsSuccess, result.Reason) switch
                {
                    (false, "Room not found") => Results.NotFound(),
                    (false, _) => Results.BadRequest(),
                    (true, _) => Results.Ok(result.Data)
                };

            });

        // acessar membros em uma sala
        app.MapGet("room/members", async (
            [FromBody] GetPlayerPayload payload,
            [FromServices] GetPlayerUseCase useCase) =>
            {
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
            
        //remove um membro de uma sala
        app.MapPut("/remove", async (
            [FromBody] RemovePlayerPayload payload,
            [FromServices] RemovePlayerUseCase useCase) =>
            {
                var result = await useCase.Do(payload);

                return (result.IsSuccess, result.Reason) switch
                {
                    (false, "Room not found") => Results.NotFound(),
                    (false, _) => Results.BadRequest(),
                    (true, _) => Results.Ok()
                };
            });
    }
}