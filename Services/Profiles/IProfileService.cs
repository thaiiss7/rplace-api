using Rplace.Models;

namespace Rplace.Services.Profiles;

public interface IProfileService
{
    Task<Profile> FindByLogin(string login);
    Task<Guid> Create(Profile profile);
}