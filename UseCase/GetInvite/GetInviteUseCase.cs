using Microsoft.EntityFrameworkCore;
using Rplace.Models;

namespace Rplace.UseCase.GetInvite;

public class GetInviteUseCase(rplaceDbContext ctx)
{
    public async Task<Result<GetInviteResponse>> Do(GetInvitePayload payload)
    {
        var invite = await ctx.Invites
        .FirstOrDefaultAsync(i => i.SenderId == payload.UserId);

        var response = new GetInviteResponse(
            invite.Accepted,
            invite.SenderId,
            invite.RoomId
        );

        return Result<GetInviteResponse>.Success(response);
    }
}