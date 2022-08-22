using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CRUD.BLL.Abstraction.Auth;
using CRUD.BLL.Base;
using CRUD.Repository.Abstraction.Auth;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Models.Entity;
using Models.Responses;

namespace CRUD.BLL.Auth
{
    public class AuthManager:Manager<UserInfo>, IAuthManager
    {
        public readonly IAuthRepository _authRepository;
        public IConfiguration _configuration;
        public AuthManager(IAuthRepository authRepository, IConfiguration _configuration, ) :base(authRepository)
        {
            _authRepository = authRepository;
            this._configuration = _configuration;
        }

        public string Authenticate(UserInfo user)
        {
            string key = "abcd";
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Email)
                }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            if (token!=null)
            {
                return tokenHandler.WriteToken(token);
            }
            return null;
        }

        public Task<UserInfo> GetUser(string email)
        {
            throw new NotImplementedException();
        }


        //public async Task<UserInfo> GetUser(string email)
        //{
        //    var user = await _authRepository.GetFirstorDefault(c=> c.Email == email);
        //    if (user != null)
        //    {
        //        return user;
        //    }

        //    return null;
        //}

        //public async Task<UserAuthResponse> GenerateTokenAsync(UserInfo model)
        //{
        //    var user = GetUser(model.Email);
        //    if (user!= null)
        //    {
        //        var claims = new[] {
        //                new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
        //                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        //                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
        //            };

        //        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        //        var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        //        var token = new JwtSecurityToken(
        //            _configuration["Jwt:Issuer"],
        //            _configuration["Jwt:Audience"],
        //            claims,
        //            expires: DateTime.UtcNow.AddMinutes(10),
        //            signingCredentials: signIn);

        //        return new UserAuthResponse
        //        {
        //            JwtSecurityToken = token,
        //            UserId = user.Id
        //        };
        //    }
        //}
    }
}
