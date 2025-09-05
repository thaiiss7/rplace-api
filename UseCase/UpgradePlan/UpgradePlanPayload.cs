using Rplace.Models;

namespace Rplace.UseCase.UpgradePlan;

public record UpgradePlanPayload(
    Guid UserId,
    Guid PlanId,
    int Code
);