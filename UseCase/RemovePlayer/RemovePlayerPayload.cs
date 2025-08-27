using Rplace.Models;

namespace Rplace.UseCase.RemovePlayer;

public record RemovePlayerPayload(
    Guid DeleteId,
    Guid UserId,
    Room Room
);