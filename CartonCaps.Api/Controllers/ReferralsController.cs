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
        [HttpGet("{page}/{size}")]
        public ActionResult<IEnumerable<ReferralDto>> ListUserReferrals(int page, int size)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            return Ok(_referralService.GetReferralsByReferrerId(Guid.Parse(userId), page, size));
        }

        [Authorize]
        [HttpPost("share-message")]
        public ActionResult<ReferralShareMessageDto> GetReferralShareMessage([FromBodyAttribute] ShareMessageRequestDto request)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var shareMessage = _referralService.GetNewReferralShareMessge(Guid.Parse(userId), request.ReferralCode, request.Channel, request.ChannelDetail);

            if (!shareMessage.IsValid)
            {
                return Conflict("Referral code invalid or not usable");
            }

            return Ok(shareMessage);
        }
    }
}
