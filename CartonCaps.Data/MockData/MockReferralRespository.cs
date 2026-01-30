using CartonCaps.Data.Entities;
using CartonCaps.Data.Interfaces;

namespace CartonCaps.Data.MockData
{
    public class MockReferralRespository(IDatabase mockDatabase) : IReferralRepository
    {
        public IReadOnlyList<Referral> GetReferralsByReferrer(Guid referrerId, int page, int size)
        {
            return mockDatabase.Referrals.Where(x=> x.ReferrerUserId == referrerId).Skip(size * page).Take(size).ToList();
        }
    }
}
