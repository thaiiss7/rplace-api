namespace Rplace.UseCase.GetPlayer;

public record GetPlayerPayload(
    Guid RoomId,
    Guid userId
);