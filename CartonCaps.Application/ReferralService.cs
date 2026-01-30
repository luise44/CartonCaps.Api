using CartonCaps.Application.Interfaces;
using CartonCaps.Data.Interfaces;
using CartonCaps.DeepLinkService.Interface;
using CartonCaps.Dto;
using CartonCaps.Transversal;

namespace CartonCaps.Application
{
    public class ReferralService(
        IReferralRepository referralRepository,
        IDeepLinkService deepLinkService,
        ITemplateService templateService) : IReferralService
    {
        private readonly IReferralRepository _referralRepository = referralRepository;
        private readonly IDeepLinkService _deepLinkService = deepLinkService;
        private readonly ITemplateService _templateService = templateService;

        public IReadOnlyList<ReferralDto> GetReferralsByReferrerId(Guid referrerId, int page, int size)
        {
            return (_referralRepository.GetReferralsByReferrerAsync(referrerId, page, size))
                .Select(x => new ReferralDto(x.FullName, x.Status, x.SubscriptionDate, x.Channel, x.ChannelDetail, x.ReferrerUserId))
                .ToList();
        }

        public ReferralShareMessageDto GetNewReferralShareMessge(Guid referrerId, string referralCode, ReferralChannel channel, AppChannelDetail? channelDetail)
        {
            var deepLinkResponse = _deepLinkService.GetShareUrl(referrerId, referralCode);
            if (!deepLinkResponse.IsValid)
            {
                return new ReferralShareMessageDto
                {
                    IsValid = false,
                };
            }

            var messageTemplate = _templateService.GetMessageTemplateByChannel(channel);

            return new ReferralShareMessageDto
            {
                IsValid = true,
                ShareUrl = deepLinkResponse.ShareUrl,
                Channel = channel,
                ChannelDetail = channelDetail,
                MessageBody = messageTemplate.MessageBody,
                Subject = messageTemplate.MessageSubject,
                ReferralCode = referralCode,
            };
        }
    }
}
