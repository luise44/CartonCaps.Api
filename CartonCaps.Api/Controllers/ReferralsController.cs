using CartonCaps.Api.Dto;
using CartonCaps.Application.Interfaces;
using CartonCaps.Dto;
using CartonCaps.Transversal;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace CartonCaps.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReferralsController(ILogger<ReferralsController> logger, IReferralService referralService) : ControllerBase
    {
        private readonly ILogger<ReferralsController> _logger = logger;
        private readonly IReferralService _referralService = referralService;

        [Authorize]
        [HttpGet("{referrerId}/{page}/{size}")]
        public ActionResult<IEnumerable<ReferralDto>> ListUserReferrals(Guid referrerId, int page, int size)
        {
            var userId = User.FindFirstValue(JwtRegisteredClaimNames.Sub);
            var email = User.FindFirstValue(JwtRegisteredClaimNames.Email);



            return Ok(_referralService.GetReferralsByReferrerId(referrerId, page, size));
        }

        [HttpPost("share-message")]
        public ActionResult<ReferralShareMessageDto> GetReferralShareMessage([FromBodyAttribute] ShareMessageRequestDto request)
        {
            return Ok(_referralService.GetNewReferralShareMessge(new Guid(), request.ReferralCode, ReferralChannel.EMAIL, null));
        }
    }
}
