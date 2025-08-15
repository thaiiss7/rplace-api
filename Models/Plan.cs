namespace Rplace.Models;

public class Plan
{
    public Guid ID { get; set; }
    public ICollection<Profile> Profiles { get; set; } = [];
    public ICollection<GiftCard> GiftCards { get; set; }
}