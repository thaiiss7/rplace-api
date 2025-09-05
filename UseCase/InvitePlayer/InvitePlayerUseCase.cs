using Rplace.Models;

namespace Rplace.UseCase.InvitePlayer;

public class InvitePlayerUseCase(rplaceDbContext ctx)
{
    public async Task<Result<InvitePlayerResponse>> Do(InvitePlayerPayload payload)
    {
        var invite = new Invite
        {
            Receiverid = payload.ReceiverId,
            SenderId = payload.SenderId,
            RoomId = payload.RoomId,
            Accepted = payload.Accepted

        };
            
        ctx.Invites.Add(invite);

        await ctx.SaveChangesAsync();

        return Result<InvitePlayerResponse>.Success(new(invite.ID));

    }

}




