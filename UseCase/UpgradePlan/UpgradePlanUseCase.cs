using Microsoft.EntityFrameworkCore;
using Rplace.Models;

namespace Rplace.UseCase.UpgradePlan;

public class UpgradePlanUseCase(rplaceDbContext ctx)
{
    public async Task<Result<UpgradePlanResponse>> Do(UpgradePlanPayload payload)
    {
        var profile = await ctx.Profiles.FirstOrDefaultAsync(p => p.ID == payload.UserId);

        profile.Plan = payload.Plan;
        await ctx.SaveChangesAsync();

        return Result<UpgradePlanResponse>.Success(null);
    }
}