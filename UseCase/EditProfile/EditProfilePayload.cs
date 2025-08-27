namespace Rplace.UseCase.EditProfile;

public record EditProfilePayload
{
    public Guid UserId;
    public string Password;
    //dados novos
    public string? NewUsername;
    public string? NewEmail;
    public string? NewBio;
    public string? NewLink;
}