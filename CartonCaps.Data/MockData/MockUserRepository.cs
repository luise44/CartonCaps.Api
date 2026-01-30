using CartonCaps.Data.Entities;
using CartonCaps.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartonCaps.Data.MockData
{
    public class MockUserRepository(IDatabase database) : IUserRepository
    {
        private readonly IDatabase _database = database;
        public User? GetUserByEmail(string email)
        {
            return _database.Users.FirstOrDefault(x=> x.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
        }
    }
}
