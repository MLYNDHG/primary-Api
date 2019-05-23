using RayPI.IService;
using RayPI.Model;
using RayPI.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace RayPI.Bussiness.Admin
{
    public class EntityBLL
    {
        private IEntity ientity = new EntityService();

        public MessageModel<string> CreateEntity(string entityName,string contentPath) {
            string[] arr = contentPath.Split("\\");
            string baseFileProvider = "";
            for (int index = 0; index < arr.Length-1; index++)
            {
                baseFileProvider += arr[index];
                baseFileProvider += "\\";
            }
            string filePath = baseFileProvider + "RayPI.Entity";
            if (ientity.CreateEntity(entityName, filePath))
            {
                return new MessageModel<string> { Success = true, Msg = "生成成功" };
            }
            else {
                return new MessageModel<string> { Success = false, Msg = "生成失败" };
            }
        }
    }
}
