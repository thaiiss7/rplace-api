using Microsoft.AspNetCore.Mvc;
using Rplace.UseCase.ColorPixel;
using Rplace.UseCase.CreateProfile;
using Rplace.UseCase.EditProfile;
using Rplace.UseCase.GetProfile;

namespace Rplace.Endpoints;

//implementar usecases com contrutores
public static class ProfileEndpoints
{
    public static void ConfigureProfileEndpoints(this WebApplication app)
    {
        //buscar dados de um usuário
        app.MapGet("profile/{username}", async (
            string username,
            [FromServices] GetProfileUseCase useCase) =>
            {
                var payload = new GetProfilePayload(username);
                var result = await useCase.Do(payload);

                return (result.IsSuccess, result.Reason) switch
                {
                    (false, "User not found") => Results.NotFound(),
                    (false, _) => Results.BadRequest(),
                    (true, _) => Results.Ok(result.Data)
                };

            });

        //criar novo usuário
        app.MapPost("profile", async (
            [FromBody] CreateProfilePayload payload,
            [FromServices] CreateProfileUseCase useCase) =>
            {
                var result = await useCase.Do(payload);
                if (result.IsSuccess)
                    return Results.Created();

                return Results.BadRequest(result.Reason);
            });

        //editar usuário
        app.MapPost("profile/{id}", async (
            Guid id,
            [FromServices] EditProfileUseCase useCase) =>
            {
                var payload = new EditProfilePayload(id);
                var result = await useCase.Do(payload);

                return (result.IsSuccess, result.Reason) switch
                {
                    (false, "Profile not found") => Results.NotFound(),
                    (false, _) => Results.BadRequest(),
                    (true, _) => Results.Ok()
                };
            });
    }
}