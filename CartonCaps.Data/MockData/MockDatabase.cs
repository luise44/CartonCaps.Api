using CartonCaps.Data.Entities;
using CartonCaps.Transversal;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CartonCaps.Data.MockData
{
    public class MockDatabase : IDatabase
    {
        private readonly MockDatabaseOptions _databaseOptions;

        private readonly JsonSerializerOptions _jsonSerializerOptions;
        public MockDatabase(IOptions<MockDatabaseOptions> databaseOptions)
        {
            _databaseOptions = databaseOptions.Value;

            _jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            Referrals = GetReferrals();
        }

        public  IList<Referral> Referrals { get; set; }

        private IList<Referral> GetReferrals()
        {
            var referralPath = Path.Combine(_databaseOptions.DataFilesPath, "Referrals.json");

            var json = File.ReadAllText(referralPath);

            return JsonSerializer.Deserialize<List<Referral>>(json, _jsonSerializerOptions) ?? new List<Referral>();
        }
    }
}
