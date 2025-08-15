using Rplace.UseCase.CreateProfile;
using Rplace.UseCase.CreatProfile;

namespace Rplace.UseCase.ColorPixel;

public class CreateProfileUseCase
{
    public async Task<Result<CreateProfileResponse>> Do(CreateProfilePayload payload)
    {
        return Result<CreateProfileResponse>.Success(null);
    }
}