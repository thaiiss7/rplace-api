namespace Rplace.UseCase.GetRoom;

public record GetRoomResponse(
    string Username,
    string Name,
    Guid OwnerId
);