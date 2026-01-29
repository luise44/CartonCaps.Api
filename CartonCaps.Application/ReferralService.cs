using CartonCaps.Application.Interfaces;
using CartonCaps.Data.Interfaces;
using CartonCaps.Dto;

namespace CartonCaps.Application
{
    public class ReferralService(IReferralRepository referralRepository) : IReferralService
    {
        private readonly IReferralRepository _referralRepository = referralRepository;

        public IReadOnlyList<ReferralDto> GetReferralsByReferrerId(Guid referrerId, int page, int size)
        {
            return (_referralRepository.GetReferralsByReferrerAsync(referrerId, page, size))
                .Select(x => new ReferralDto(x.FullName, x.Status, x.SubscriptionDate, x.Channel, x.ChannelDetail, x.ReferrerUserId))
                .ToList();
        }
    }
}
