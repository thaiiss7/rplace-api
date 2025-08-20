using Microsoft.AspNetCore.Mvc;
using Rplace.UseCase.ColorPixel;
using Rplace.UseCase.GetPixel;

namespace Rplace.Endpoints;

public static class PixelEndpoints
{
    public static void ConfigurePixelEndpoints(this WebApplication app)
    {

        app.MapGet("pixel/{roomId}", async (
            Guid roomId,
            [FromServices] GetPixelUseCase useCase) =>
            {
                var payload = new GetPixelPayload(roomId);
                var result = await useCase.Do(payload);

                return (result.IsSuccess, result.Reason) switch
                {
                    (false, "Pixel not found") => Results.NotFound(),
                    (false, _) => Results.BadRequest(),
                    (true, _) => Results.Ok(result.Data)
                };
            });

        app.MapPost("pixel", async (
            [FromBody] ColorPixelPayload payload,
            [FromServices] ColorPixelUseCase useCase) =>
            {
                var result = await useCase.Do(payload);

                if (result.IsSuccess)
                    return Results.Created();

                return Results.BadRequest(result.Reason);
            });
    }
}