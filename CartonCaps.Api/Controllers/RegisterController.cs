using CartonCaps.Application.Interfaces;
using CartonCaps.Transversal;
using Microsoft.AspNetCore.Mvc;

namespace CartonCaps.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController(IRegisterService registerService) : ControllerBase
    {
        private readonly IRegisterService _registerService = registerService;

        [HttpGet("onboardinginfo")]
        public OnboardingForm GetOnboardingInfo([FromQuery] string? referralCode)
        {
            return _registerService.GetOnboardingForm(referralCode);
        }
    }
}
