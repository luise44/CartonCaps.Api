using CartonCaps.Application.Interfaces;
using CartonCaps.Data.Interfaces;
using CartonCaps.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartonCaps.Application
{
    public class LoginService(IUserRepository userRepository) : ILoginService
    {
        private readonly IUserRepository _userRepository = userRepository;
        public LoginValidationDto ValidateUser(string email, string password)
        {
            var user = _userRepository.GetUserByEmail(email);

            if (user is null)
            {
                return new LoginValidationDto(false);
            }

            if (!user.Password.Equals(password, StringComparison.OrdinalIgnoreCase))
            {
                return new LoginValidationDto(false);
            }

            return new LoginValidationDto(true, new UserDto(user.Id, user.Email));
        }
    }
}
