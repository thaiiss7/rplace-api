namespace Rplace.Endpoints;

public static class GiftCards
{
    public static void ConfigureGiftCardEndpoints(this WebApplication app)
    {
        //trocar de plano
        app.MapPost("/plan", async (
            [FromBody] UpgradePlanPayload payload,
            [FromServices] UpgradePlanUseCase useCase) =>
            {
                var result = await useCase.Do(payload);

                return (result.IsSuccess, result.Reason) switch
                {
                    (false, "Plan not found") => Results.NotFound(),
                    (false, _) => Results.BadRequest(),
                    (true, _) => Results.Ok()
                };
            });
    }
}