using Cimo.Dtos;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Hotel_Management.Utils
{
    public class JWTUtil
    {
        private static readonly string SecretKey = Environment.GetEnvironmentVariable("Secret_Key"); // Nên để trong appsettings.json
                                                                                                     //private static readonly string Issuer = Environment.GetEnvironmentVariable("Valid_Issuer");
                                                                                                     //private static readonly string Audience = Environment.GetEnvironmentVariable("Valid_Audience");
        public static string GenerateToken(JwtPayloadDto payloadDto)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(SecretKey);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, payloadDto.Sub),
                new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64)
            };

            claims.AddRange(payloadDto.Authorities.Select(role => new Claim("authorities", role)));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(1),
                //NotBefore = null,
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }


        public static ClaimsPrincipal? ValidateToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(SecretKey);

            try
            {
                var parameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    //ValidIssuer = Issuer,
                    ValidateAudience = false,
                    //ValidAudience = Audience,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero // Không cho phép trễ thời gian
                };
                
                var info = tokenHandler.ValidateToken(token, parameters, out SecurityToken validatedTokentest);
                foreach (var claim in info.Claims)
                {
                    Console.WriteLine($"Type: {claim.Type}, Value: {claim.Value}");
                }
                // Nếu hợp lệ → trả về ClaimsPrincipal chứa user info
                return tokenHandler.ValidateToken(token, parameters, out SecurityToken validatedToken);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Token validation failed: {ex.Message}");
                // Token hết hạn, giả mạo hoặc sai
                return null;
            }
        }
    }
}
