using RayPI.Token.Model;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace RayPI.Token
{
    /// <summary>
    /// 该类只有一个方法叫IssueJWT，我们将tokenModel传递给这个函数，它们根据tokenModel生成JWT字符串
    /// 然后将JWT字符串作为Key，tokenModel作为value存入系统缓存中
    /// </summary>
    public class RayPIToken
    {
        public RayPIToken() { }
        /// <summary>
        /// NuGet包
        /// IdentityModel？？？
        /// </summary>
        /// <param name="tokenModel"></param>
        /// <param name="expiresSliding"></param>
        /// <param name="expiresAbsoulte"></param>
        /// <returns></returns>
        public static string IssueJWT(TokenModel tokenModel, TimeSpan expiresSliding, TimeSpan expiresAbsoulte) {
            DateTime UTC = DateTime.UtcNow;
            Claim[] claims = new Claim[] {
                new Claim(JwtRegisteredClaimNames.Sub,tokenModel.Sub),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat,UTC.ToString(),ClaimValueTypes.Integer64)
            };
            JwtSecurityToken jwt = new JwtSecurityToken(
                issuer: "RayPI",//jwt签发者，非必需
                audience: tokenModel.Uname,//jwt的接收该方，非必需
                claims:claims,//生命集合
                expires:UTC.AddHours(12),//指定token的生命周期。unix时间戳格式，非必需
                signingCredentials:new Microsoft.IdentityModel.Tokens
                .SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes("RayPI's Secret Key")),
                SecurityAlgorithms.HmacSha256));//使用私钥进行签名加密
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            RayPIMemoryCache.AddMemoryCache(encodedJwt,tokenModel,expiresSliding,expiresAbsoulte);//将JWT字符串和TokenmModel作为Key和Value存入缓存
            return encodedJwt;
        }
    }
}
