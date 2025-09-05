using Rplace.Models;

namespace Rplace.UseCase.GetRoom;

// public record MemberData
// {
//     public string MyProperty { get; set; }
// }

public record GetRoomResponse(
    string Name,
    Guid OwnerId
    // ICollection<MemberData> Members
);