using Rplace.Models;

namespace Rplace.UseCase.GetRoom;

public record MemberData
(
    string Username,
    string? RoleName
);

public record GetRoomResponse(
    string Name,
    Guid OwnerId,
    IEnumerable<MemberData> Members
);