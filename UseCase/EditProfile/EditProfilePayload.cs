namespace Rplace.UseCase.EditProfile;

public record EditProfilePayload(
    Guid UserId,
    string Username
);