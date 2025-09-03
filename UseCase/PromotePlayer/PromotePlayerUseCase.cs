using Microsoft.EntityFrameworkCore;
using Rplace.Models;

namespace Rplace.UseCase.PromotePlayer;

public class PromotePlayerUseCase(rplaceDbContext ctx)
{
    public async Task<Result<PromotePlayerResponse>> Do(PromotePlayerPayload payload)
    {
        var roleIDUser = await ctx.Roles.FirstOrDefaultAsync(r => r.ID == payload.RoleId);
        var roleUser = roleIDUser.Name;
        
        var roleIDPromoter = await ctx.Roles.FirstOrDefaultAsync(r => r.ID == payload)

        if (role == "Dono")
        {

        }
        else if (role == "Administrador")

            return Result<PromotePlayerResponse>.Success(null);
    }
}