using Rplace.Models;

namespace Rplace.UseCase.GetRoom;

public class GetRoomUseCase(rplaceDbContext ctx)
{
    public async Task<Result<GetRoomResponse>> Do(GetRoomPayload payload)
    {
        

        return Result<GetRoomResponse>.Success(null);
    }
}