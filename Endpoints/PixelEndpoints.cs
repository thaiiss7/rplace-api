using Microsoft.AspNetCore.Mvc;
using Rplace.UseCase.ColorPixel;

namespace Rplace.Endpoints;

public static class PixelEndpoints
{
    public static void ConfigurePixelEndpoints(this WebApplication app)
    {

        _ = app.MapGet("pixel/{room}", async (
         
            [FromServices] GetPixelUseCase useCase) =>
            {
                var payload = new GetPixelPayload();
                var result = await useCase.Do(payload);

                return (result.IsSuccess, result.Reason) switch
                {
                    (false, "Pixel not found") => Results.NotFound(),
                    (false, _) => Results.BadRequest(),
                    (true, _) => Results.Ok(result.Data)
                };
            });

        _ = app.MapPost("color", async (
            [FromBody] ColorPixelPayload payload,
            [FromServices] ColorPixelUseCase useCase) =>
            {
                var result = await useCase.Do(payload);

                return (result.IsSuccess, result.Reason) switch
                {
                    (false, "Pixel not found") => Results.NotFound(),
                    (false, _) => Results.BadRequest(),
                    (true, _) => Results.Ok(result.Data)
                };
            });
    }
}