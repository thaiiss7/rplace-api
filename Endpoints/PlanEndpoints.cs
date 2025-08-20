using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rplace.UseCase.GetPlan;

namespace Rplace.Endpoints;

public static class PlanEndpoints
{
    public static void ConfigurePlanEndpoints(this WebApplication app)
    {
        // acessar plano
        app.MapGet("plan/{id}", async (
            Guid id,
            [FromServices] GetPlanUseCase useCase) =>
            {
                var payload = new GetPlanPayload(id);
                var result = await useCase.Do(payload);

                return (result.IsSuccess, result.Reason) switch
                {
                    (false, "Plan not found") => Results.NotFound(),
                    (false, _) => Results.BadRequest(),
                    (true, _) => Results.Ok(result.Data)
                };
            });
    }
}