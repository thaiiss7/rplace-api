namespace Rplace.Models;

public class ItemRoom
{
    public Guid ID { get; set; }
    public ICollection<Profile> Members { get; set; } = [];
    public Room Room { get; set; }
    public Guid RoomId { get; set; }
    public ICollection<Role> Roles { get; set; } = [];

}