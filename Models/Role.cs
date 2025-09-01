namespace Rplace.Models;

public class Role
{
    public Guid ID { get; set; }
    public string Name { get; set; }
    public ICollection<Profile> Profiles { get; set; }
    public Guid RoomId { get; set; }
    public Room RoleRoom { get; set; }
    public ItemRoom ItemRoom { get; set; }
}