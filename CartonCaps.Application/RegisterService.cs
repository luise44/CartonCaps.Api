using CartonCaps.Application.Interfaces;
using CartonCaps.Transversal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartonCaps.Application
{
    public class RegisterService : IRegisterService
    {
        public OnboardingForm GetOnboardingForm(string referralCode)
        {
            return string.IsNullOrEmpty(referralCode) ? OnboardingForm.DEFAULT : OnboardingForm.REFERRED;
        }
    }
}
