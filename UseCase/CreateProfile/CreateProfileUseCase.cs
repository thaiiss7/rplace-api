using Rplace.Models;
using Rplace.Services.Password;
using Rplace.Services.Profiles;
using Rplace.UseCase.CreateProfile;
using Rplace.UseCase.CreatProfile;

namespace Rplace.UseCase.ColorPixel;

public class CreateProfileUseCase
(
    IProfileService profileService,
    IPasswordService passwordService
)
{
    public async Task<Result<CreateProfileResponse>> Do(CreateProfilePayload payload)
    {
        var profile = new Profile
        {
            Bio = payload.Bio,
            Email = payload.Email,
            Username = payload.Username,
            Plan = payload.Plan,
            Password = passwordService.Hash(payload.Password)
        };

        await profileService.Create(profile); 

        return Result<CreateProfileResponse>.Success(new());
    }
}