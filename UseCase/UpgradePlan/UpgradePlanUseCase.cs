using Microsoft.EntityFrameworkCore;
using Rplace.Models;

namespace Rplace.UseCase.UpgradePlan;

public class UpgradePlanUseCase(rplaceDbContext ctx)
{
    public async Task<Result<UpgradePlanResponse>> Do(UpgradePlanPayload payload)
    {
        var profile = await ctx.Profiles.FirstOrDefaultAsync(p => p.ID == payload.UserId);
        var giftCard = await ctx.GiftCards.FirstOrDefaultAsync(
            g => g.Code == payload.Code);
        var plan = await ctx.Plans.FirstOrDefaultAsync(p => p.ID == payload.PlanId);

        if (!giftCard.Actived)
            return Result<UpgradePlanResponse>.Fail("Invalid Code");

        giftCard.Actived = false;
        profile.PlanId = payload.PlanId;
        profile.Plan = plan;

        await ctx.SaveChangesAsync();

        return Result<UpgradePlanResponse>.Success(null);
    }
}