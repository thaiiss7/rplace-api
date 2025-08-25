namespace Rplace.UseCase.EditProfile;

public record EditProfileResponse(
    Guid UserId,
    string? NewUsername,
    string? NewEmail,
    string? NewBio,
    string? NewLink
);