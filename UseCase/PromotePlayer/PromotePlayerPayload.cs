using Rplace.Models;

namespace Rplace.UseCase.PromotePlayer;

public record PromotePlayerPayload(
    Guid UserId,
    Guid PromoterId,
    Guid RoomId,
    Guid RoleId
);