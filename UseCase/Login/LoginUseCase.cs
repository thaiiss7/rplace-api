using Rplace.Services.JWT;
using Rplace.Services.Password;
using Rplace.Services.Profiles;

namespace Rplace.UseCase.Login;

// operação para fazer um login
public class LoginUseCase(
    IProfileService profileService, // usa o serviço de perfil
    IPasswordService passwordService, // usa o serviço de senha
    IJWTService jWTService // usa o serviço de jwt
)
{
    // task que retorna um resultado do login, usa os dados de loginpayload
    public async Task<Result<LoginResponse>> Do(LoginPayload payload)
    {
        var user = await profileService.FindByLogin(payload.Login); // acha o usuário com o login recebido
        if (user is null) // se não achar o usuário retorna usuário não encontrado
            return Result<LoginResponse>.Fail("User not found");

        var passwordMatch = passwordService // compara a senha recebida com a senha no banco de dados
            .Compare(payload.Password, user.Password);

        if (!passwordMatch) // se a senha não for a mesma, retorna usuário não encontrado
            return Result<LoginResponse>.Fail("User not found");

        var jwt = jWTService.CreateToken(new(
            user.ID, user.Username, user.PlanId
        )); // cria um jwt usando o id e username do usuário

        return Result<LoginResponse>.Success(new LoginResponse(jwt));
        // retorna que a operação deu certo e entrega o jwt
    }
}