using Microsoft.EntityFrameworkCore;
using Rplace.Models;

namespace Rplace.UseCase.GetRoom;

public class GetRoomUseCase(rplaceDbContext ctx)
{
    public async Task<Result<GetRoomResponse>> Do(GetRoomPayload payload)
    {
        var room = await ctx.Rooms
        .Include(r => r.Members)
        .FirstOrDefaultAsync(r => r.ID == payload.RoomId);

        // var response = new GetRoomResponse
        // (
        //     room.Name,
        //     room.ProfileId,
        //     from m in room.Members
        //     select new MemberData
        // );


        return Result<GetRoomResponse>.Success(null);
    }
}