namespace Rplace.Models;

public class Room
{
    public Guid ID { get; set; }
    public string Name { get; set; }
    public int Size { get; set; }
    public Guid ProfileId { get; set; }
    public Profile Author { get; set; }
    public ICollection<Pixel> Pixels { get; set; }
}