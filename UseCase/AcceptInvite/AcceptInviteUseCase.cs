namespace Rplace.UseCase.AcceptInvite;

public class AcceptInviteUseCase
{
    public async Task<Result<AcceptInviteResponse>> Do(AcceptInvitePayload payload)
    {
        return Result<AcceptInviteResponse>.Success(null);
    }
}