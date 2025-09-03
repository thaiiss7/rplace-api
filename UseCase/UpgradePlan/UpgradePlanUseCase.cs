using Rplace.Models;

namespace Rplace.UseCase.UpgradePlan;

public class UpgradePlanUseCase(rplaceDbContext ctx)
{
    public async Task<Result<UpgradePlanResponse>> Do(UpgradePlanPayload payload)
    {
        return Result<UpgradePlanResponse>.Success(null);
    }
}