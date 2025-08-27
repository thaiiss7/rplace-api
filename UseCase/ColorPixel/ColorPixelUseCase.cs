namespace Rplace.UseCase.ColorPixel;

public class ColorPixelUseCase
{
    public async Task<Result<ColorPixelResponse>> Do(ColorPixelPayload payload)
    {
        return Result<ColorPixelResponse>.Success(null);
    }
}