using Rplace.Models;

namespace Rplace.UseCase.UpgradePlan;

public record UpgradePlanPayload(
    Guid UserId,
    Plan Plan
);