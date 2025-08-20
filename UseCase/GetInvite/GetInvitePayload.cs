namespace Rplace.UseCase.GetInvite;

public record GetInvitePayload(
    Guid id,
    Guid UserId
);