using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using core.Entities;
using core.Entities.ServiceEntities;
using core.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace infrastructure.Services.Token
{
    public class TokenService : ITokenService
    {
        private readonly SymmetricSecurityKey _key;
        private readonly IOptions<TokenSettings> _tokenSettings;


        public TokenService(IOptions<TokenSettings> tokenSettings)
        {
            _tokenSettings  = tokenSettings;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenSettings.Value.Secret));
        }

        public Tuple<String, DateTime> CreateToken(string role)
        {
            var authClaims = new List<Claim>
            {
                // new Claim(ClaimTypes.Email, user.Email),
               // new Claim(ClaimTypes.Name, user.Name),
               // new Claim("id", user.Id.ToString())
            };

           //  authClaims.Add(new Claim(ClaimTypes.GivenName, user.Name));
            authClaims.Add(new Claim(ClaimTypes.Role, role));
           // authClaims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
            
            return CreateToken(authClaims);
        }

        public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes( _tokenSettings.Value.Secret)),
                ValidateLifetime = false
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);
            if (securityToken is not JwtSecurityToken jwtSecurityToken || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Invalid token");

            return principal;
        }
       
        public Tuple<String, DateTime> CreateToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenSettings.Value.Secret));
            _ = int.TryParse( _tokenSettings.Value.TokenValidityInMinutes, out int tokenValidityInMinutes);

            var token = new JwtSecurityToken(
                issuer: _tokenSettings.Value.ValidIssuer,
                audience: _tokenSettings.Value.ValidAudience,
                expires: DateTime.Now.AddDays(tokenValidityInMinutes),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );

          
            _ = int.TryParse(_tokenSettings.Value.RefreshTokenValityInidDays, out int refreshTokenValidityInDays);

            var _token = new JwtSecurityTokenHandler().WriteToken(token);
            var userTokens = Tuple.Create(_token, DateTime.Now.AddDays(refreshTokenValidityInDays));
            

            return userTokens;    
        }
    }
}