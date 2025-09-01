using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Rplace.Models;

namespace Rplace.UseCase.CreateRoom;

public class CreateRoomUseCase(rplaceDbContext ctx)
{
    public async Task<Result<CreateRoomResponse>> Do(CreateRoomPayload payload)
    {
        var profile = await ctx.Profiles.FirstOrDefaultAsync(p => p.ID == payload.ProfileId);
        var plan = profile.Plan;

        if (payload.Size <= plan.RoomSize)
        {
            var room = new Room
            {
                Name = payload.Name,
                Size = payload.Size,
                ProfileId = payload.ProfileId
            };
            
            ctx.Rooms.Add(room);

            await ctx.SaveChangesAsync();

            return Result<CreateRoomResponse>.Success(new(room.ID));
        }

        return Result<CreateRoomResponse>.Fail("");
    }
}