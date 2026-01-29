using CartonCaps.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartonCaps.Data.Interfaces
{
    public interface IReferralRepository
    {
        IReadOnlyList<Referral> GetReferralsByReferrerAsync(Guid referrerId, int page, int size);
    }
}
