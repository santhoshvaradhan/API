using Microsoft.IdentityModel.Tokens;
using ProductAPI.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProductAPI.Services
{
    public class TokenService
    {
        public static string CreateToken(User user)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ThisIsASuperLongSecretKeyForJWT@2025#Secure!"));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var tokeOptions = new JwtSecurityToken
                (
                    issuer: "https://localhost:7141",
                    audience: "https://localhost:7141",

                    claims: new List<Claim>
                    {
                            new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                            new Claim(ClaimTypes.Name, user.UserName),
                            new Claim(ClaimTypes.Role, user.Role)
                    }
                    ,
                    expires: DateTime.Now.AddMinutes(5),
                    signingCredentials: signinCredentials
               );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);

            return tokenString;
        }
    }
}
