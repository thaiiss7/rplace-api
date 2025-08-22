using Rplace.Models;

namespace Rplace.UseCase.GetProfile;

public record GetProfileResponse(
    string Username,
    string? Bio,
    string? Link,
    Plan Plan
);