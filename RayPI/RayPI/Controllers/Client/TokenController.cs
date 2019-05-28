using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RayPI.Token;
using RayPI.Token.Model;

namespace RayPI.Controllers.Client
{
    /// <summary>
    /// 获取令牌
    /// </summary>
    [Produces("application/json")]
    [Route("api/Client/[controller]")]
    [EnableCors("AllowSpecificOrigin")]
    public class TokenController : Controller
    {
        /// <summary>
        /// 生成JWT
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetJWTStr(TokenModel model) {
            TimeSpan date1 = new TimeSpan(4, 20, 33);

            TimeSpan date2 = new TimeSpan(4, 20, 33);
            return Json(RayPIToken.IssueJWT(model,date1, date2));
        }
    }
}