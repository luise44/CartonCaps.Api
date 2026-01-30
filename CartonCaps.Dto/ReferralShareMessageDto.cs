using CartonCaps.Transversal;

namespace CartonCaps.Dto
{
    public record ReferralShareMessageDto
    {
        public string ReferralCode { get; set; } = string.Empty;

        public ReferralChannel Channel { get; set; }

        public AppChannelDetail? ChannelDetail { get; set; }

        public string ShareUrl { get; set; } = string.Empty;

        public string? Subject { get; set; }

        public string MessageBody { get; set; } = string.Empty;

        public bool IsValid { get; set; }
    }
}
