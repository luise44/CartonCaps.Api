using CartonCaps.DeepLinkService.Dto;

namespace CartonCaps.DeepLinkService.Interface
{
    public interface IDeepLinkService
    {
        DeepLinkResponseDto GetShareUrl(Guid referrerId, string referralCode);
    }
}
