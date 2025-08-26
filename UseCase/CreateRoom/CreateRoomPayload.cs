namespace Rplace.UseCase.CreateRoom;

public record CreateRoomPayload
{
    public string Name;
    public int Size;
    public Guid ProfileId;
}