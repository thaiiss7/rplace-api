namespace Rplace.Models;

public class Role
{
    public Guid ID { get; set; }
    public Guid ProfileId { get; set; }
    public Profile RoleProfile { get; set; }
    public Guid RoomId { get; set; }
    public Room RoleRoom { get; set; }
}