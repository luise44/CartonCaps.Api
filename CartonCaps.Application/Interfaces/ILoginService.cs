using CartonCaps.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartonCaps.Application.Interfaces
{
    public interface ILoginService
    {
        LoginValidationDto ValidateUser(string email, string password);
    }
}
