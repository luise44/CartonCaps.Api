namespace CartonCaps.DeepLinkService.Dto
{
    public record DeepLinkResponseDto(bool IsValid, string? ShareUrl = null);
}
