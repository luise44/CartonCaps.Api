using CartonCaps.Transversal;

namespace CartonCaps.Data.Entities
{
    public class Referral
    {
        public string FullName { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public DateTime SubscriptionDate { get; set; }
        public ReferralChannel Channel { get; set; }
        public AppChannelDetail ChannelDetail { get; set; }
        public Guid ReferrerUserId { get; set; }
    }
}
