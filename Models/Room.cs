namespace Rplace.Models;

public class Room
{
    public Guid ID { get; set; }
    public string Name { get; set; }
    public int Size { get; set; }
    public Guid ProfileId { get; set; }
    public Profile Owner { get; set; } //dono da sala
    public ICollection<Pixel> Pixels { get; set; }
    public ICollection<Profile> Members { get; set; }
}