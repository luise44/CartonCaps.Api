using CartonCaps.Transversal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartonCaps.Application.Interfaces
{
    public interface IRegisterService
    {
        OnboardingForm GetOnboardingForm(string referralCode);
    }
}
