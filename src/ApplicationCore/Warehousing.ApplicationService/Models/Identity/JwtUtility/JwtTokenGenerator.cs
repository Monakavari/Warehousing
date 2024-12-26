using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Warehousing.ApplicationService.Models.Identity.JwtUtility.Contract;
using Warehousing.Domain.Entities;

namespace Warehousing.ApplicationService.Models.Identity.JwtUtility
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        private readonly UserManager<ApplicationUsers> _userManager;
        private readonly SymmetricSecurityKey _key;
        string _securityKey;
        public JwtTokenGenerator(IConfiguration config, UserManager<ApplicationUsers> userManager)
        {
            _userManager = userManager;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"]));
            _securityKey = config["SecurityKey"];
        }

        public async Task<string> CreateTokenAsync(ApplicationUsers user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.NameId, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName)
            };

            var roles = await _userManager.GetRolesAsync(user);
            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

            //Hash Token SecurityKey Oriented
            var encryptorKey = Encoding.UTF8.GetBytes(_securityKey);
            var encryptorCred = new EncryptingCredentials(new SymmetricSecurityKey(encryptorKey)
                , SecurityAlgorithms.Aes128KW, SecurityAlgorithms.Aes128CbcHmacSha256);
            //
            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);
            var tokenDescriber = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                //تاریخ انقضای توکن
                Expires = DateTime.Now.AddHours(8),
                //امضای توکن
                SigningCredentials = creds,
                Issuer = "Porsnet.Ir",
                Audience = "Porsnet.Ir",
                EncryptingCredentials = encryptorCred
                //NotBefore = DateTime.Now.AddMinutes(5)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriber);
            return tokenHandler.WriteToken(token);
        }
    }
}
