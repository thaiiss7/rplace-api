namespace Rplace.Models;

public class Invite
{
    public Guid ID { get; set; }
    public Guid Receiverid { get; set; }
    public Guid SenderId { get; set; }
    public Profile Receiver { get; set; } //receive = receber
    public Profile Sender { get; set; } //send = enviar
    public Guid RoomId { get; set; }
    public Room InviteRoom { get; set; }
    public bool Accepted { get; set; } = false;
}