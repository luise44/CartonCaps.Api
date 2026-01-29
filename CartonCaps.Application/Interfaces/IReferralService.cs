using CartonCaps.Dto;
using CartonCaps.Transversal;

namespace CartonCaps.Application.Interfaces
{
    public interface IReferralService
    {
        IReadOnlyList<ReferralDto> GetReferralsByReferrerId(Guid referrerId, int page, int size);
        ReferralShareMessageDto GetNewReferralShareMessge(Guid referrerId, string referralCode, ReferralChannel channel, AppChannelDetail? channelDetail);

        bool IsReferralCodeValid(Guid referrerId, string referralCode);

    }
}
