using Microsoft.Identity.Client;

namespace Rplace.UseCase.GetInvite;

public record GetInviteData(
    bool Accept,
    Guid SenderId,
    Guid RoomId
);

public record GetInviteResponse(
    ICollection<GetInviteData> Invites
);