using Microsoft.EntityFrameworkCore;
using Rplace.Models;

namespace Rplace.UseCase.GetPixel;

public class GetPixelUseCase(rplaceDbContext ctx)
{
    public async Task<Result<GetPixelResponse>> Do(GetPixelPayload payload)
    {
        var room = await ctx.Rooms
        .FirstOrDefaultAsync(p => p.ID == payload.RoomId);

        var response = new GetPixelResponse
        (
            room.Pixels
        );

        return Result<GetPixelResponse>.Success(response);
    }
}