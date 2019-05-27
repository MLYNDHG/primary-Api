﻿using Microsoft.AspNetCore.Http;
using RayPI.Token;
using RayPI.Token.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RayPI.AuthHelper
{
    /// <summary>
    /// 该类后面我们把他注册为中间件,用于验证并授权客户端发来的HTTP请求
    /// Token授权中间件
    /// </summary>
    public class TokenAuth
    {
        /// <summary>
        /// http委托
        /// </summary>
        private readonly RequestDelegate _next;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="next"></param>
        public TokenAuth(RequestDelegate next) {
            _next = next;
        }
        /// <summary>
        /// 验证授权
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        public Task Invoke(HttpContext httpContext) {
            var headers=httpContext.Request.Headers;
            //验证是否包含Ahthorization请求头，如果不包含返回context进行下一个中间件
            if (!headers.ContainsKey("Authorization")) {
                return _next(httpContext);
            }
            var tokenStr = headers["Authorization"];
            try {
                string jwtStr = tokenStr.ToString().Substring("Bearer".Length).Trim();
                //验证缓存中是否存在改jwt字符串
                if (!RayPIMemoryCache.Exists(jwtStr)) {
                    return httpContext.Response.WriteAsync("非法请求");
                }
                TokenModel tm = (TokenModel)RayPIMemoryCache.Get(jwtStr);
                //提取tokenModel中的Sub属性进行authorization认证
                List<Claim> lc = new List<Claim>();
                Claim c = new Claim(tm.Sub + "Type", tm.Sub);
                lc.Add(c);
                ClaimsIdentity identity = new ClaimsIdentity(lc);
                ClaimsPrincipal principal = new ClaimsPrincipal(identity);
                httpContext.User = principal;
                return _next(httpContext);
            } catch (Exception) {
                return httpContext.Response.WriteAsync("token验证异常");
            }
        }
    }
}
