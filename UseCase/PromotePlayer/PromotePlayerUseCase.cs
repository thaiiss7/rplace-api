using Microsoft.EntityFrameworkCore;
using Rplace.Models;

namespace Rplace.UseCase.PromotePlayer;

public class PromotePlayerUseCase(rplaceDbContext ctx)
{
    public async Task<Result<PromotePlayerResponse>> Do(PromotePlayerPayload payload)
    {
        var user = await ctx.Profiles.FirstOrDefaultAsync(u => u.ID == payload.UserId);
        var promoter = await ctx.Profiles.FirstOrDefaultAsync(p => p.ID == payload.PromoterId);

        var room = await ctx.Rooms
        .Include(r => r.Members)
            .ThenInclude(m => m.ID)
        .Include()

        .FirstOrDefaultAsync(r => r.ID == payload.RoomId);

        return Result<PromotePlayerResponse>.Success(null);
    }
}