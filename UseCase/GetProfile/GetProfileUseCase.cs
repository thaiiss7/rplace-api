namespace Rplace.UseCase.GetProfile;

public class GetProfileUseCase
{
    public async Task<Result<GetProfileResponse>> Do(GetProfilePayload payload)
    {
        return Result<GetProfileResponse>.Success(null);
    }
}