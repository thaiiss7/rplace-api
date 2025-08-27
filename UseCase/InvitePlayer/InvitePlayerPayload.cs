namespace Rplace.UseCase.InvitePlayer;

public record InvitePlayerPayload
{ // Criação sempre usar {} e colocar public na frente do Guid
    public Guid SenderId;
    public Guid Receiverid;
    public Guid RoomId;
    public bool Accepted;
}


