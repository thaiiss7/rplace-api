using Rplace.Models;

namespace Rplace.UseCase.GetPlan;

public class GetPlanUseCase(rplaceDbContext ctx)
{
    public async Task<Result<GetPlanResponse>> Do(GetPlanPayload payload)
    {
        var plan = await ctx.Plans
        .FirstOrDefaultAsync(p => p.ID == payload.PlanId);

        var response = new GetPlanUseCase
        (
            plan.Name,
            plan.RoomSize
        );

        return Result<GetPlanResponse>.Success(response);
    }
}