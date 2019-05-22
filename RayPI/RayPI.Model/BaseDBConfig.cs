using System;

namespace RayPI.Model
{
    /// <summary>
    /// 配置连接字符串
    /// BaseDBConfig用于存放数据库的配置信息，比如数据库连接字符串
    /// (这些配置信息还可以分离出来，存放到主项目的json文件中，以供读写)
    /// </summary>
    public class BaseDBConfig        
    {
        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        public static string ConnectionString = "Provider=SQLOLEDB.1;Password=PS123321;Persist Security Info=True;User ID=sa;Initial Catalog=NetCoreApiDB;Data Source=.";
    }
}
