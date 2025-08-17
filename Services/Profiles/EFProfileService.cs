using Microsoft.EntityFrameworkCore;
using Rplace.Models;

namespace Rplace.Services.Profiles;

// implementa a interface
public class EFProfileService(rplaceDbContext ctx) : IProfileService
{
    public async Task<Guid> Create(Profile profile)
    {
        ctx.Profiles.Add(profile); // adiciona um perfil no banco de dados
        await ctx.SaveChangesAsync(); // salva no banco de dados
        return profile.ID; // retorna um id para o novo perfil

    }

    public async Task<Profile> FindByLogin(string login)
    {
        var profile = await ctx.Profiles.FirstOrDefaultAsync( 
            p => p.Username == login || p.Email == login 
        ); // procura o primeiro perfil com o mesmo username e email do login recebido
        return profile; // retorna o perfil encontrado (pode ser nulo se não achar nenhum)
    }
}