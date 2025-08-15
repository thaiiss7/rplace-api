namespace Rplace.UseCase.PromotePlayer;

public class PromotePlayerUseCase
{
    public async Task<Result<PromotePlayerResponse>> Do(PromotePlayerPayload payload)
    {
        return Result<PromotePlayerResponse>.Success(null);
    }
}