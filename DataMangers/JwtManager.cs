using CarParkAvailability.Utilities.Classes;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CarParkAvailability.DataMangers
{
    public class JwtManager
    {
        private readonly byte[] _key;
        private JwtSecurityTokenHandler _tokenHandler;

        public JwtManager()
        {
            _tokenHandler = new JwtSecurityTokenHandler();
            _key = Encoding.ASCII.GetBytes("0f081b0455394428aa3a31f2472f2441"); 
        }

        public string GenerateToken(int userId)
        {
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("user_id", userId.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(_key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = _tokenHandler.CreateToken(tokenDescriptor);
            var jwtString = _tokenHandler.WriteToken(token);
            return jwtString;
        }

        public ClaimsPrincipal VerifyToken(string token)
        {
            var claim = _tokenHandler.ValidateToken(token, new TokenValidationParameters { 
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(_key),
                ValidateLifetime = true,
                ValidateIssuer = false,
                ValidateAudience = false,
                ClockSkew = TimeSpan.Zero
            }, out SecurityToken validatedToken);

            return claim;
        }

        public int DecodeToken(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(token.Split(" ")[1]); 
            var securityToken = jsonToken as JwtSecurityToken;

            int id = Convert.ToInt32(securityToken.Claims.First(claim => claim.Type == "user_id").Value);

            return id;
        }
    }
}
