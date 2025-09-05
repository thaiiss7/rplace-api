using Microsoft.EntityFrameworkCore;
using Rplace.Models;

namespace Rplace.UseCase.GetRoom;

public class GetRoomUseCase(rplaceDbContext ctx)
{
    public async Task<Result<GetRoomResponse>> Do(GetRoomPayload payload)
    {
        var room = await ctx.Rooms
        .Include(r => r.Owner)
        .Include(r => r.Members)
            .ThenInclude(m => m.Roles)
        .FirstOrDefaultAsync(r => r.ID == payload.RoomId);

        var response = new GetRoomResponse
        (
            room.Name,
            room.ProfileId,
            from m in room.Members
            select new MemberData
            (
                m.Username,
                m.Roles.Where(r => r.RoomId == payload.RoomId).FirstOrDefault()?.Name
            )
        );

        return Result<GetRoomResponse>.Success(response);
    }
}