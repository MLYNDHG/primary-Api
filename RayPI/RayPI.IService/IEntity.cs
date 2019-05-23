using System;
using System.Collections.Generic;
using System.Text;

namespace RayPI.IService
{
    /// <summary>
    /// 生成实体类接口
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// 生成实体类
        /// </summary>
        /// <param name="entityName">实体类名称</param>
        /// <param name="filePath">实体类生成路径</param>
        /// <returns></returns>
        bool CreateEntity(string entityName,string filePath);
    }
}
