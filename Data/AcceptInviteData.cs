namespace Rplace.Data;

public record AcceptInviteData(
    bool Accept,
    Guid InviteId
);