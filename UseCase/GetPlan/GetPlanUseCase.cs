namespace Rplace.UseCase.GetPlan;

public class GetPlanUseCase
{
    public async Task<Result<GetPlanResponse>> Do(GetPlanPayload payload)
    {
        return Result<GetPlanResponse >.Success(null);
    }
}