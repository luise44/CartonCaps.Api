using CartonCaps.Transversal;

namespace CartonCaps.Dto
{
    public record ReferralDto(
        string FullName,
        string Status,
        DateTime SubscriptionDate,
        ReferralChannel Channel,
        AppChannelDetail? ChannelDetail,
        Guid ReferrerUserId
    );
}
