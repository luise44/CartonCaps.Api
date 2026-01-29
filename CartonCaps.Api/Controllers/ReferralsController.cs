using CartonCaps.Application.Interfaces;
using CartonCaps.Data.Entities;
using CartonCaps.Dto;
using Microsoft.AspNetCore.Mvc;

namespace CartonCaps.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReferralsController(ILogger<ReferralsController> logger, IReferralService referralService) : ControllerBase
    {
        private readonly ILogger<ReferralsController> _logger = logger;
        private readonly IReferralService _referralService = referralService;

        [HttpGet("{referrerId}/{page}/{size}")]
        public IEnumerable<ReferralDto> Get(Guid referrerId, int page, int size)
        {
            return _referralService.GetReferralsByReferrerId(referrerId, page, size);
        }
    }
}
