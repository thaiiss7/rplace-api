namespace Rplace.UseCase.InvitePlayer;

public class InvitePlayerUseCase
{
    public async Task<Result<InvitePlayerResponse>> Do(InvitePlayerPayload payload)
    {
        return Result<InvitePlayerResponse>.Success(null);
    }
}