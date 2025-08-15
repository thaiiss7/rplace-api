namespace Rplace.UseCase.GetInvite;

public class GetInviteUseCase
{
    public async Task<Result<GetInviteResponse>> Do(GetInvitePayload payload)
    {
        return Result<GetInviteResponse>.Success(null);
    }
}