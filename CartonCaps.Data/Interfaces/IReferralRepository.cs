using CartonCaps.Data.Entities;

namespace CartonCaps.Data.Interfaces
{
    public interface IReferralRepository
    {
        IReadOnlyList<Referral> GetReferralsByReferrerAsync(Guid referrerId, int page, int size);
    }
}
