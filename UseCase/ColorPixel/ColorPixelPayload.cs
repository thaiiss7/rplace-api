namespace Rplace.UseCase.ColorPixel;

public record ColorPixelPayload(
    int X,
    int Y,
    int Red,
    int Green,
    int Blue,
    Guid RoomId
);
