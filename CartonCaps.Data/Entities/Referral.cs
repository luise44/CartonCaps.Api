using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartonCaps.Data.Entities
{
    public class Referral
    {
        public string FullName { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public DateTime SubscriptionDate { get; set; }
        public string Channel { get; set; } = string.Empty;
        public string? ChannelDetail { get; set; }
        public Guid ReferrerUserId { get; set; }
    }
}
