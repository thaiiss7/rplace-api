using Microsoft.EntityFrameworkCore;
using Rplace.Models;

namespace Rplace.UseCase.RemovePlayer;

public class RemovePlayerUseCase(rplaceDbContext ctx)
{
    public async Task<Result<RemovePlayerResponse>> Do(RemovePlayerPayload payload)
    {
        
        var player = await ctx.Rooms.FirstOrDefaultAsync(r => r.ID == payload.UserId);
            
        ctx.Rooms.Remove(player);

        await ctx.SaveChangesAsync();

    
        return Result<RemovePlayerResponse>.Success(null);
    }
}