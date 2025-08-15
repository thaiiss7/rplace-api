namespace Rplace.UseCase.EditProfile;

public class EditProfileUseCase
{
    public async Task<Result<EditProfileResponse>> Do(EditProfilePayload payload)
    {
        return Result<EditProfileResponse>.Success(null);
    }
}