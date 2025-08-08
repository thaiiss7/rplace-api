namespace Rplace.Models;

public class Plan
{
    public Guid ID { get; set; }
    public ICollection<Profile> Profiles { get; set; } = [];
    public Guid GiftCardId { get; set; }
    public GiftCard GiftCard { get; set; }
}