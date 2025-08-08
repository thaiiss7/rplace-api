using System.Drawing;

namespace Rplace.Models;

public class Pixel
{
    public Guid ID { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    public int Red { get; set; }
    public int Green { get; set; }
    public int Blue { get; set; }
    public Room PixelRoom { get; set; }
    public Guid RoomId { get; set; }
}