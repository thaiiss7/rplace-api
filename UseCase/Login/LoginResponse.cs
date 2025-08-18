namespace Rplace.UseCase.Login;

// retorna um token de identificação
public record LoginResponse(
    string Token
);