using CartonCaps.Application.Interfaces;
using CartonCaps.Dto;
using CartonCaps.Transversal;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CartonCaps.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(
        ILoginService loginService,
        IOptions<JwtOptions> jwtOptions) : ControllerBase
    {
        private readonly ILoginService _loginService = loginService;
        private JwtOptions _jwtOptions = jwtOptions.Value;

        [HttpPost("login")]
        public ActionResult<TokenResponseDto> Login([FromBody] LoginRequestDto loginRequest)
        {
            var userValidated = _loginService.ValidateUser(loginRequest.Email, loginRequest.Password);

            if (!userValidated.IsLoginValid)
            {
                return Unauthorized("Invalid credentials");
            }

            var claims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Sub, userValidated.User.UserId.ToString()),
                new(JwtRegisteredClaimNames.Email, loginRequest.Email),
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };
            
            var encodedKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.Key));
            var credentials = new SigningCredentials(encodedKey, SecurityAlgorithms.HmacSha256);

            var expires = DateTime.UtcNow.AddMinutes(_jwtOptions.ExpiresMinutes);

            var token = new JwtSecurityToken(
                issuer: _jwtOptions.Issuer,
                audience: _jwtOptions.Audience,
                claims: claims,
                expires: expires,
                signingCredentials: credentials
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return Ok(new TokenResponseDto(tokenString, DateTime.UtcNow));
        }
    }
}
