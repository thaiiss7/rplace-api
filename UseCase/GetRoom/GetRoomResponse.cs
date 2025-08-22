namespace Rplace.UseCase.GetRoom;

public record GetRoomResponse(
    string Name,
    Guid OwnerId
);