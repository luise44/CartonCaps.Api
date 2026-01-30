using CartonCaps.Application.Interfaces;
using CartonCaps.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartonCaps.Application
{
    public class LoginService : ILoginService
    {
        public LoginValidationDto ValidateUser(string email, string password)
        {
            if (email != "luis@email.com")
            {
                return new LoginValidationDto(false);
            }

            if (password != "123")
            {
                return new LoginValidationDto(false);
            }

            var user = new UserDto(Guid.NewGuid(), email);

            return new LoginValidationDto(true, user);
        }
    }
}
