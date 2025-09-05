namespace Rplace.UseCase.GetPixel;

public record GetPixelData(
    int X,
    int Y,
    int Red,
    int Green,
    int Blue
);

public record GetPixelResponse(
    IEnumerable<GetPixelData> Pixels
);