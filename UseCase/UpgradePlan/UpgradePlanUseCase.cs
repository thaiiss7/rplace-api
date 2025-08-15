namespace Rplace.UseCase.UpgradePlan;

public class UpgradePlanUseCase
{
    public async Task<Result<UpgradePlanResponse>> Do(UpgradePlanPayload payload)
    {
        return Result<UpgradePlanResponse>.Success(null);
    }
}