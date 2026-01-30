using CartonCaps.Data.Entities;

namespace CartonCaps.Data.MockData
{
    public interface IDatabase
    {
        IList<Referral> Referrals { get; set; }

        IList<User> Users { get; set; }
    }
}
