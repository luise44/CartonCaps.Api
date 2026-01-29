namespace CartonCaps.Dto
{
    public record ReferralDto(
        string FullName,
        string Status,
        DateTime SubscriptionDate,
        string Channel,
        string? ChannelDetail,
        Guid ReferrerUserId
    );
}
