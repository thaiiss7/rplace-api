using Rplace.Models;

namespace Rplace.UseCase.PromotePlayer;

public record PromotePlayerPayload(
    Guid UserId,
    Guid RoomId,
    Guid RoleId
);