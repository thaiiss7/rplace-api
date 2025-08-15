namespace Rplace.UseCase.GetPlayer;

public class GetPlayerUseCase
{
    public async Task<Result<GetPlayerResponse>> Do(GetPlayerPayload payload)
    {
        return Result<GetPlayerResponse>.Success(null);
    }
}