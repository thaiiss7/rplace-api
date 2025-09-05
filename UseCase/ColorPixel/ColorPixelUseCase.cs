using Rplace.Models;

namespace Rplace.UseCase.ColorPixel;

public class ColorPixelUseCase(rplaceDbContext ctx)
{
    public async Task<Result<ColorPixelResponse>> Do(ColorPixelPayload payload)
    {
        var pixel = new Pixel
        {
            X = payload.X,
            Y = payload.Y,
            Red = payload.Red,
            Green = payload.Green,
            Blue = payload.Blue,
            RoomId = payload.RoomId
        };

        ctx.Pixels.Add(pixel);
        await ctx.SaveChangesAsync();

        return Result<ColorPixelResponse>.Success(new(pixel.ID));
    }
}