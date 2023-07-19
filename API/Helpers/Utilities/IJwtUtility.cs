// using System.IdentityModel.Tokens.Jwt;
// using System.Security.Claims;
// using System.Text;
// using API.Extentions.Constants;
// using Microsoft.IdentityModel.Tokens;
// using API.Models;
// using System.Security.Cryptography;

// namespace API.Helpers.Utilities
// {
//     public interface IJwtUtility
//     {
//         public string GenerateJwtToken(SystemUser user);
//         public string ValidateJwtToken(string token);
//         public SystemUserRefreshToken GenerateRefreshToken(SystemUser user);
//     }

//     public class JwtUtility : IJwtUtility
//     {
//         private readonly IConfiguration _configuration;

//         public JwtUtility(IConfiguration configuration)
//         {
//             _configuration = configuration;
//         }

//         public string GenerateJwtToken(SystemUser user)
//         {
//             var claims = new[]
//             {
//                 new Claim(ClaimTypes.NameIdentifier, user.Username),
//                 new Claim(ClaimTypes.Name, user.Fullname)
//             };
//             var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection(AppSettingsConst.Tokens).Value));
//             var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

//             var tokenDescriptor = new SecurityTokenDescriptor
//             {
//                 Subject = new ClaimsIdentity(claims),
//                 Expires = DateTime.Now.AddDays(1),
//                 SigningCredentials = creds
//             };

//             var tokenHandler = new JwtSecurityTokenHandler();
//             var token = tokenHandler.CreateToken(tokenDescriptor);
//             return tokenHandler.WriteToken(token);
//         }

//         public string ValidateJwtToken(string token)
//         {
//             if (token == null)
//                 return null;

//             var tokenHandler = new JwtSecurityTokenHandler();
//             var key = Encoding.ASCII.GetBytes(_configuration.GetSection(AppSettingsConst.Tokens).Value);
//             try
//             {
//                 tokenHandler.ValidateToken(token, new TokenValidationParameters
//                 {
//                     ValidateIssuerSigningKey = true,
//                     IssuerSigningKey = new SymmetricSecurityKey(key),
//                     ValidateIssuer = false,
//                     ValidateAudience = false,
//                     ClockSkew = TimeSpan.Zero
//                 }, out SecurityToken validatedToken);

//                 var jwtToken = (JwtSecurityToken)validatedToken;
//                 var username = jwtToken.Claims.First(x => x.Type == "nameid").Value;

//                 return username;
//             }
//             catch
//             {
//                 return null;
//             }
//         }

//         public SystemUserRefreshToken GenerateRefreshToken(SystemUser user)
//         {
//             // Tạo Refrest Token có hạn là 7 ngày
//             var rngCryptoServiceProvider = RandomNumberGenerator.Create();
//             var randomBytes = new byte[64];
//             rngCryptoServiceProvider.GetBytes(randomBytes);

//             var refreshToken = new SystemUserRefreshToken
//             {
//                 Token = Convert.ToBase64String(randomBytes),
//                 Expires = DateTime.UtcNow.AddDays(7),
//                 CreatedTime = DateTime.UtcNow,
//                 Username = user.Username
//             };

//             return refreshToken;
//         }
//     }
// }