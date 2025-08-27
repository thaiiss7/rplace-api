namespace Rplace.Services.JWT;

// interface com função para criar um token (recebe os dados do usuário)
public interface IJWTService
{
    string CreateToken(ProfileToAuth data);
}