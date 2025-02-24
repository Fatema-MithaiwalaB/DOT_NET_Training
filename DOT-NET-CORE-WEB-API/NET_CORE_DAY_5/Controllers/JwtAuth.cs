using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security;
using NET_CORE_DAY_5.Entities;
using NET_CORE_DAY_5.Models;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;

namespace NET_CORE_DAY_5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JwtAuth(IConfiguration configuration) : ControllerBase
    {
        public static User user = new();
        [HttpPost("Register")]
        public ActionResult<User> Register (UserDTO request)
        {
            var hashedPassword = new PasswordHasher<User>()
                .HashPassword(user, request.Password);

            user.Username = request.Username;
            user.PasswordHash = hashedPassword;

            return Ok(user);
        }

        [HttpPost("login")]
        public ActionResult<string> Login(UserDTO request)
        {
            if(user.Username != request.Username)
            {
                return BadRequest("User not found");
            }

            if (new PasswordHasher<User>().VerifyHashedPassword(user,user.PasswordHash, request.Password) == PasswordVerificationResult.Failed) 
            {
                return BadRequest("Wrong Password");
            }

            string token = CreateToken(user);
            return Ok(token);
        }

        private string CreateToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetValue<string>("AppSettings:Token")!));

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

            var tokenDescriptor = new JwtSecurityToken(
                issuer: configuration.GetValue<string>("AppSettings:Issuer"),
                audience: configuration.GetValue<string>("AppSettings:Audience"),
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(10),
                signingCredentials: cred);

            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        }
    }
}
