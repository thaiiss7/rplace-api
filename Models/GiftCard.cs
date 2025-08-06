namespace Rplace.Models;

public class GiftCard
{
    public Guid ID { get; set; }
    public Plan PlanGiftCard { get; set; }
    public Guid PlanId { get; set; }
}