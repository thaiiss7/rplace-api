using System.Drawing;

namespace Rplace.Models;

public class Pixel
{
    public Guid ID { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    public Color Color { get; set; }
    public Room PixelRoom { get; set; }
    public Guid RoomId { get; set; }
}