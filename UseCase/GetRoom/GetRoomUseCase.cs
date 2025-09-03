using Microsoft.EntityFrameworkCore;
using Rplace.Models;

namespace Rplace.UseCase.GetRoom;

public class GetRoomUseCase(rplaceDbContext ctx)
{
    public async Task<Result<GetRoomResponse>> Do(GetRoomPayload payload)
    {
        var profile = await ctx.Profiles.FirstOrDefaultAsync(p => p.ID == payload.ProfileId);

        var response = new GetRoomResponse
        (
            
        );


        return Result<GetRoomResponse>.Success(response);
    }
}