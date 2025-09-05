using Microsoft.EntityFrameworkCore;
using Rplace.Models;

namespace Rplace.UseCase.PromotePlayer;

public class PromotePlayerUseCase(rplaceDbContext ctx)
{
    public async Task<Result<PromotePlayerResponse>> Do(PromotePlayerPayload payload)
    {
        var user = await ctx.Profiles.FirstOrDefaultAsync(u => u.ID == payload.UserId);
        var userRole = user.Roles
        .Where(r => r.RoomId == payload.RoomId)
        .FirstOrDefault()?.Level;

        var promoter = await ctx.Profiles.FirstOrDefaultAsync(p => p.ID == payload.PromoterId);
        var promoterRole = promoter.Roles
        .Where(r => r.RoomId == payload.RoomId)
        .FirstOrDefault()?.Level;

        var room = await ctx.Rooms
        .Include(r => r.Members)
            .ThenInclude(m => m.Roles)
        .FirstOrDefaultAsync(r => r.ID == payload.RoomId);

        if (promoterRole > userRole &&
            promoterRole > payload.NewRole)
        {
            userRole = payload.NewRole;
            await ctx.SaveChangesAsync();

            return Result<PromotePlayerResponse>.Success(null);
        }

        return Result<PromotePlayerResponse>.Fail("Forbiden"); //proibido
    }
}