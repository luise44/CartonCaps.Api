using CartonCaps.DeepLinkService.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartonCaps.DeepLinkService.Interface
{
    public interface IDeepLinkService
    {
        DeepLinkResponseDto GetShareUrl(Guid referrerId, string referralCode);

        bool IsReferralCodeValid(Guid referrerId, string referralCode);
    }
}
