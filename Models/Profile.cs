namespace Rplace.Models;

public class Profile
{
    public Guid ID { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string? Bio { get; set; }
    public Plan Plan { get; set; }
    public Guid PlanId { get; set; }
    public ICollection<Room> Rooms { get; set; }
    public ICollection<Invite> Invites { get; set; }
    public Guid ItemRoomId { get; set; }
    public ItemRoom ItemRoom { get; set; }
}