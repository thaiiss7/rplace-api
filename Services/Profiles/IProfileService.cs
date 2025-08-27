using Rplace.Models;

namespace Rplace.Services.Profiles;

// serviços para o perfil
public interface IProfileService
{
    Task<Profile> FindByLogin(string login); //achar um perfil por login
    Task<Guid> Create(Profile profile); // taak de guid para criar um perfil
}