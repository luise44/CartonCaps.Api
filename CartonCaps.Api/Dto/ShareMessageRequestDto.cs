using CartonCaps.Transversal;

namespace CartonCaps.Api.Dto
{
    public class ShareMessageRequestDto
    {
        public string ReferralCode { get; set; }

        public ReferralChannel Channel { get; set; }

        public AppChannelDetail? ChannelDetail { get; set; }
    }
}
