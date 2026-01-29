using CartonCaps.DeepLinkService.Dto;
using CartonCaps.DeepLinkService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartonCaps.DeepLinkService
{
    public class DeepLinkService : IDeepLinkService
    {
        public DeepLinkResponseDto GetShareUrl(Guid referrerId, string referralCode)
        {
            return new DeepLinkResponseDto
            {
                shareUrl = $"www.CartonCaps.com/install/{referralCode}",
            };
        }

        public bool IsReferralCodeValid(Guid referrerId, string referralCode)
        {
            if (referralCode == "3f7a9c2e-4b61-4d9c-9b2e-7d8e1a4c6f21")
            {
                return false;
            }

            return true;
        }
    }
}
