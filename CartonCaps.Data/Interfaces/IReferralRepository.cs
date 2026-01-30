using CartonCaps.Data.Entities;

namespace CartonCaps.Data.Interfaces
{
    public interface IReferralRepository
    {
        IReadOnlyList<Referral> GetReferralsByReferrer(Guid referrerId, int page, int size);
    }
}
