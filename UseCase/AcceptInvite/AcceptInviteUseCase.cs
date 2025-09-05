using Microsoft.EntityFrameworkCore;
using Rplace.Models;

namespace Rplace.UseCase.AcceptInvite;

public class AcceptInviteUseCase(rplaceDbContext ctx)
{
    public async Task<Result<AcceptInviteResponse>> Do(AcceptInvitePayload payload)
    {
        //procura o banco no banco de dados o convite com o id passado
        var invite = await ctx.Invites.FirstOrDefaultAsync(i => i.ID == payload.InviteId);

        if (payload.UserId != invite.Receiverid)
            return Result<AcceptInviteResponse>.Fail("O convite nao eh seu");

        //acessa o booleano do convite
            //coloca no booleano o mesmo valor passado no payload
        invite.Accepted = payload.Accept;
        //salva as alterações no banco de dados
        await ctx.SaveChangesAsync();
        
        return Result<AcceptInviteResponse>.Success(null);
    }
}