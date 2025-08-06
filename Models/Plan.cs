namespace Rplace.Models;

public class Plan
{
    public Guid ID { get; set; }
    public Guid ProfileId { get; set; }
    public Profile PlanProfile { get; set; }

}