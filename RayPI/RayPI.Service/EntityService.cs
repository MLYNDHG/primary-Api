using RayPI.IService;
using RayPI.Model;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace RayPI.Service
{
    public class EntityService:IEntity
    {
        public SqlSugarClient db = BaseDB.GetClient();
        public bool CreateEntity(string entityName, string filePath)
        {
            try
            {
                db.DbFirst.IsCreateAttribute().Where(entityName).CreateClassFile(filePath);
                return true;
            }
            catch (Exception)
            {

                return false ;
            }
        }
    }
}
