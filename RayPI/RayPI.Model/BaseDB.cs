using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RayPI.Model
{
    public class BaseDB
    {
        /// <summary>
        /// BaseDB类现在只放置了一个函数叫GetClient(),
        /// 这个函数会返回一个SqlSugarClient类,而这个Client类就是CRUD关键
        /// BaseDB用于返回SqlSugar的SqlSugarClient类，数据层一般直接继承该类。
        /// </summary>
        /// <returns></returns>
        public static SqlSugarClient GetClient() {
            SqlSugarClient db = new SqlSugarClient(
                new ConnectionConfig() {
                    ConnectionString = BaseDBConfig.ConnectionString,
                    DbType = DbType.SqlServer,
                    IsAutoCloseConnection = true
                });
            db.Aop.OnLogExecuting = (sql, pars) =>
            {
                Console.WriteLine(sql + "\r\n" + db.Utilities.SerializeObject(pars.ToDictionary(it =>
                    it.ParameterName, it => it.Value)));
                Console.WriteLine();
            };
            return db;
        }
    }
}
