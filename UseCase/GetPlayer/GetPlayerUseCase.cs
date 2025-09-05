using Microsoft.EntityFrameworkCore;
using Rplace.Models;

namespace Rplace.UseCase.GetPlayer;

public class GetPlayerUseCase(rplaceDbContext ctx)
{
    public async Task<Result<GetPlayerResponse>> Do(GetPlayerPayload payload)
    {
        var room = await ctx.Rooms
        .Include(r => r.Members)
        .FirstOrDefaultAsync(r => r.ID == payload.RoomId);

        var response = new GetPlayerResponse
        (
            [ ..
                from m in room.Members
                select new GetPlayerData(
                    m.Username,
                    m.Link
                )
            ]
        );


        return Result<GetPlayerResponse>.Success(response);
    }
}