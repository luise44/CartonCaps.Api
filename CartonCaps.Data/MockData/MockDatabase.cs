using CartonCaps.Data.Entities;
using CartonCaps.Transversal;

namespace CartonCaps.Data.MockData
{
    public class MockDatabase : IDatabase
    {
        public MockDatabase()
        {
            Referrals = GetReferrals();
            Users = GetUsers();
        }

        public  IList<Referral> Referrals { get; set; }
        public IList<User> Users { get; set; }

        private IList<Referral> GetReferrals()
        {
            return [
                new Referral
                {
                    Channel = ReferralChannel.SMS,
                    FullName = "Joe Smith",
                    ReferrerUserId = Guid.Parse("b8cbb6b9-6b22-4b71-a2c3-7f02a9c6e4f1"),
                    Status = "Completed",
                    SubscriptionDate = DateTime.UtcNow.AddDays(-15),
                },
                new Referral
                {
                    Channel = ReferralChannel.EMAIL,
                    FullName = "Willam Parr",
                    ReferrerUserId = Guid.Parse("3f7a9c2e-4b61-4d9c-9b2e-7d8e1a4c6f21"),
                    Status = "Completed",
                    SubscriptionDate = DateTime.UtcNow.AddDays(-1),
                },
                new Referral
                {
                    Channel = ReferralChannel.APP,
                    FullName = "Sonya Smith",
                    ReferrerUserId = Guid.Parse("9e2c9a5e-9c6a-4c3c-8f73-0f87a0a0c6d9"),
                    Status = "Completed",
                    SubscriptionDate = DateTime.UtcNow.AddDays(-1),
                    ChannelDetail = AppChannelDetail.WHATSAPP
                }
            ];
        }

        private IList<User> GetUsers()
        {
            return new List<User>
            {
                new User
                {
                    Email = "luis@email.com",
                    Password = "123",
                    Id = Guid.NewGuid(),
                }
            };
        }
    }
}
