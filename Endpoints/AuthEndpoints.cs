using Microsoft.AspNetCore.Mvc;
using Rplace.UseCase.Login;

namespace Rplace.Endpoints;

public static class AuthEndpoints
{
    public static void ConfigureAuthEndpoints(this WebApplication app)
    {
        app.MapPost("auth", async (
            [FromBody]LoginPayload payload,
            [FromServices]LoginUseCase useCase) =>
        {
            var result = await useCase.Do(payload);
            if (!result.IsSuccess)
                return Results.BadRequest();
            
            return Results.Ok(result.Data);
        });
    }
}