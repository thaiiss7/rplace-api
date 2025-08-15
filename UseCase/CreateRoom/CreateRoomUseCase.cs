namespace Rplace.UseCase.CreateRoom;

public class CreateRoomUseCase
{
    public async Task<Result<CreateRoomResponse>> Do(CreateRoomPayload payload)
    {
        return Result<CreateRoomResponse>.Success(null);
    }
}