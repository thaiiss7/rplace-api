using Microsoft.EntityFrameworkCore;
using Rplace.Models;

namespace Rplace.UseCase.EditProfile;

public class EditProfileUseCase(rplaceDbContext ctx)
{
    public async Task<Result<EditProfileResponse>> Do(EditProfilePayload payload)
    {
        var profile = await ctx.Profiles.FirstOrDefaultAsync(p => p.ID == payload.UserId);
        var password = profile.Password;

        if (password == payload.Password)
        {
            profile.Username = payload.NewUsername;
            profile.Email = payload.NewEmail;
            profile.Bio = payload.NewBio;
            profile.Link = payload.NewLink;

            await ctx.SaveChangesAsync();

            return Result<EditProfileResponse>.Success(null);
        }
        return Result<EditProfileResponse>.Fail("Password invalid");
    }
}