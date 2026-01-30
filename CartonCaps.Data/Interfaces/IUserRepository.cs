using CartonCaps.Data.Entities;

namespace CartonCaps.Data.Interfaces
{
    public interface IUserRepository
    {
        User? GetUserByEmail(string email);
    }
}
