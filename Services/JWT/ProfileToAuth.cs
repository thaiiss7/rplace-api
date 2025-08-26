namespace Rplace.Services.JWT;

// dados necessários para um perfil ser autentificado: guid e
public record ProfileToAuth(
    Guid ProfileId,
    string Username,
    Guid PlanId
);