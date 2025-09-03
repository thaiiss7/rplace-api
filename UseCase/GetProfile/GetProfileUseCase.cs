using Microsoft.EntityFrameworkCore;
using Rplace.Models;

namespace Rplace.UseCase.GetProfile;

public class GetProfileUseCase(rplaceDbContext ctx)
{
    public async Task<Result<GetProfileResponse>> Do(GetProfilePayload payload)
    {
        var profile = await ctx.Profiles
        .FirstOrDefaultAsync(p => p.Username == payload.Username);

        var response = new GetProfileResponse
        (
            profile.Username,
            profile.Bio,
            profile.Link,
            profile.Plan  
        );

        return Result<GetProfileResponse>.Success(response);
    }
}