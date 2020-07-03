using ApiAuth.Services.Dto;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ApiAuth.Services.Api.Services
{
    public class TokenService
    {
        #region Attributes
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        #endregion

        #region Constructors
        public TokenService(IConfiguration configuration, IMapper mapper)
        {
            this._configuration = configuration;
            this._mapper = mapper;
        }
        #endregion

        #region Public Methods
        public AuthenticationModelDto GenerateToken(UserSignUpDto userSignUpDto)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var secretKey = jwtSettings.GetValue<string>("SecretKey");
            int minutes = jwtSettings.GetValue<int>("MinutestoExpiration");
            var issuer = jwtSettings.GetValue<string>("Issuer");
            var audience = jwtSettings.GetValue<string>("Audience");

            var key = Encoding.ASCII.GetBytes(secretKey);

            var claims = GetClaims(userSignUpDto);

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddMinutes(minutes),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            );

            return new AuthenticationModelDto
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                MinutesToExpiration = minutes,
                TokenDate = DateTime.UtcNow,
                UserLogged = _mapper.Map<UserLoggedDto>(userSignUpDto)
            };
        }
        #endregion

        #region Private methods
        public List<Claim> GetClaims(UserSignUpDto userSignUpDto)
        {
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, userSignUpDto.UserName));
            claims.Add(new Claim(ClaimTypes.Email, userSignUpDto.Email));

            return claims;
        }
        #endregion


    }
}
