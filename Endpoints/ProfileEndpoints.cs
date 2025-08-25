using Microsoft.AspNetCore.Mvc;
using Rplace.UseCase.ColorPixel;
using Rplace.UseCase.CreateProfile;
using Rplace.UseCase.EditProfile;
using Rplace.UseCase.GetProfile;
using Rplace.UseCase.RemovePlayer;
using Rplace.UseCase.UpgradePlan;

namespace Rplace.Endpoints;

//implementar usecases com contrutores
public static class ProfileEndpoints
{
    public static void ConfigureProfileEndpoints(this WebApplication app)
    {
        //buscar dados de um usuário
        //mapget: serve para buscar dados
        app.MapGet("profile/{username}", async (
            string username,
            [FromServices] GetProfileUseCase useCase) => // declara o username e o UseCase que vai ser usado
            {
                var payload = new GetProfilePayload(username);
                var result = await useCase.Do(payload); // result são dados retornados pela UseCase (usando o payload)

                return (result.IsSuccess, result.Reason) switch
                {
                    (false, "User not found") => Results.NotFound(), // se o perfil não foi encontrado 
                    (false, _) => Results.BadRequest(), // se as informações pedidas não foram passadas
                    (true, _) => Results.Ok(result.Data) // se deu certo, retorna os dados pedidos
                };

            });

        //criar novo usuário
        //mappost: colocar novos dados no banco
        app.MapPost("profile", async (
            [FromBody] CreateProfilePayload payload,
            [FromServices] CreateProfileUseCase useCase) => // pede um payload e um UseCase que será usado
            {
                var result = await useCase.Do(payload);
                if (result.IsSuccess)
                    return Results.Created(); // se a requisição deu certo, informa que criou um perfil

                return Results.BadRequest(result.Reason); // se não, informa que não teve informações suficientes
            });

        //editar usuário
        app.MapPost("profile/edit", async (
            [FromBody] EditProfilePayload payload,
            [FromServices] EditProfileUseCase useCase) =>
            {
                var result = await useCase.Do(payload);

                return (result.IsSuccess, result.Reason) switch
                {
                    (false, "Profile not found") => Results.NotFound(),
                    (false, "Password invalid") => Results.Unauthorized(),
                    (false, _) => Results.BadRequest(),
                    (true, _) => Results.Ok()
                };
            });

        //remove um membro de uma sala
        app.MapPost("/remove", async (
            [FromBody] RemovePlayerPayload payload,
            [FromServices] RemovePlayerUseCase useCase) =>
            {
                var result = await useCase.Do(payload);

                return (result.IsSuccess, result.Reason) switch
                {
                    (false, "Profile not found") => Results.NotFound(),
                    (false, _) => Results.BadRequest(),
                    (true, _) => Results.Ok()
                };
            });

        //trocar de plano
        app.MapPost("/plan", async (
            [FromBody] UpgradePlanPayload payload,
            [FromServices] UpgradePlanUseCase useCase) =>
            {
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