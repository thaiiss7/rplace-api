namespace Rplace.UseCase.Login;

// dados para fazer o login
public record LoginPayload
(
    string Login,
    string Password
);