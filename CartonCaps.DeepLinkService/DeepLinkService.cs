using CartonCaps.DeepLinkService.Dto;
using CartonCaps.DeepLinkService.Interface;

namespace CartonCaps.DeepLinkService
{
    public class DeepLinkService : IDeepLinkService
    {
        static readonly string[] validCodes = { "CODE1", "CODE2" };

        public DeepLinkResponseDto GetShareUrl(Guid referrerId, string referralCode)
        {
            if (!validCodes.Contains(referralCode, StringComparer.OrdinalIgnoreCase))
            {
                return new DeepLinkResponseDto(false);
            }

            return new DeepLinkResponseDto(true, $"www.CartonCaps.com/install/{referralCode}");
        }
    }
}
