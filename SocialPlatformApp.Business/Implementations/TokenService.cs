/*using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SocialPlatformApp.Business.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

public class TokenService : ITokenService
{
    private readonly IConfiguration _configuration;

    public TokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string JWTService(string userName, int userId)
    {
        *//*var secretKey = _configuration["JwtSettings:SecretKey"];*//*
        var secretKey = "kjvfcuwe)@(f_IfiuHJO_)!*(#$(!&*$_!;adoaidai;ad;a;";

        *//*        if (string.IsNullOrEmpty(secretKey))
                {
                    throw new ArgumentNullException("SecretKey", "The JWT SecretKey configuration value cannot be null or empty.");
                }*//*

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, userName),
            new Claim("userId", userId.ToString())
            //here we can handle role based
        };

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.UtcNow.AddHours(6), // Token expiration time
            signingCredentials: new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
                SecurityAlgorithms.HmacSha256)
        );

        string realToken = new JwtSecurityTokenHandler().WriteToken(token);

        return realToken;
    }
}
*/