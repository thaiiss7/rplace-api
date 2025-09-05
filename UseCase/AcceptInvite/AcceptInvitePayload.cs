namespace Rplace.UseCase.AcceptInvite;

public record AcceptInvitePayload(
    bool Accept,
    Guid InviteId,
    Guid UserId
);