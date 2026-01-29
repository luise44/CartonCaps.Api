using CartonCaps.Api.Dto;
using CartonCaps.Application.Interfaces;
using CartonCaps.Data.Entities;
using CartonCaps.Dto;
using CartonCaps.Transversal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Drawing;

namespace CartonCaps.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReferralsController(ILogger<ReferralsController> logger, IReferralService referralService) : ControllerBase
    {
        private readonly ILogger<ReferralsController> _logger = logger;
        private readonly IReferralService _referralService = referralService;

        [HttpGet("{referrerId}/{page}/{size}")]
        public IEnumerable<ReferralDto> ListUserReferrals(Guid referrerId, int page, int size)
        {
            return _referralService.GetReferralsByReferrerId(referrerId, page, size);
        }

        [HttpPost("share-message")]
        public ReferralShareMessageDto GetReferralShareMessage([FromBodyAttribute] ShareMessageRequestDto request)
        {
            return _referralService.GetNewReferralShareMessge(new Guid(), request.ReferralCode, ReferralChannel.EMAIL, null);
        }
    }
}
