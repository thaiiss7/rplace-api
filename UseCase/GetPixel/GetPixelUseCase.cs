namespace Rplace.UseCase.GetPixel;

public class GetPixelUseCase
{
    public async Task<Result<GetPixelResponse>> Do(GetPixelPayload payload)
    {
        return Result<GetPixelResponse>.Success(null);
    }
}