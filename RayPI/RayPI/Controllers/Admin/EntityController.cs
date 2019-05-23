using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RayPI.Bussiness.Admin;

namespace RayPI.Controllers.Admin
{
    /// <summary>
    /// 生成实体类
    /// </summary>
    [Produces("application/json")]
    [Route("api/admin/Entity")]
    public class EntityController : Controller
    {
        private EntityBLL bll = new EntityBLL();

        private readonly IHostingEnvironment _hostingEnvironment;

        /// <summary>
        /// 生成实体类控制器的构造函数
        /// </summary>
        /// <param name="hostingEnvironment"></param>
        public EntityController(IHostingEnvironment hostingEnvironment) {
            _hostingEnvironment = hostingEnvironment;
        }
        /// <summary>
        /// 根据数据库表名称生成实体类
        /// </summary>
        /// <param name="entityname"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult CreateEntity(string entityname = null) {
            if (entityname==null) {
                return Json("参数为空");
            }
            return Json(bll.CreateEntity(entityname, _hostingEnvironment.ContentRootPath));
        }
    }
}