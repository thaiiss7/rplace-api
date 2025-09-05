namespace Rplace.Models;

public class GiftCard
{
    public Guid ID { get; set; }
    public Plan PlanGiftCard { get; set; }
    public Guid PlanId { get; set; }
    public int Code { get; set; }
    public int Expiration { get; set; } //validade
    public bool Actived { get; set; }
}