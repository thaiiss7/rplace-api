namespace Rplace.UseCase.GetPlayer;

public record GetPlayerData(
    string Username,
    string Link
);

public record GetPlayerResponse(
    ICollection<GetPlayerData> Members
);