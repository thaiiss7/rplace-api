namespace Rplace.UseCase.RemovePlayer;

public class RemovePlayerUseCase
{
    public async Task<Result<RemovePlayerResponse>> Do(RemovePlayerPayload payload)
    {
        return Result<RemovePlayerResponse>.Success(null);
    }
}