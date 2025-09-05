using Microsoft.EntityFrameworkCore;
using Rplace.Models;

namespace Rplace.UseCase.RemovePlayer;

public class RemovePlayerUseCase(rplaceDbContext ctx)
{
    public async Task<Result<RemovePlayerResponse>> Do(RemovePlayerPayload payload)
    {
        var player = await ctx.Rooms.FirstOrDefaultAsync(r => r.ID == payload.UserId);

        if (player is null)
        {
            return Result<RemovePlayerResponse>.Fail("User not found");
        }

        ctx.Rooms.Remove(player);
        await ctx.SaveChangesAsync();

        return Result<RemovePlayerResponse>.Success(null);
    }
}