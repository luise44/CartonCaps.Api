namespace CartonCaps.Api.Dto
{
    public class ShareMessageRequestDto
    {
        public string ReferralCode { get; set; }

        public string Channel { get; set; }

        public string? ChannelDetail { get; set; }
    }
}
