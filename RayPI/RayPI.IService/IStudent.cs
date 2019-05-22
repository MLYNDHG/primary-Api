using RayPI.Entity;
using RayPI.Model;
using System;

namespace RayPI.IService
{
    //接口层我建议先把基础的CRUD写出来，后期需要其他功能在往上加
    //这里我把5个功能定义为基础功能
    //一.GetPageList 获取分页列表功能
    //二. Get 根据Id获取单个实体
    //三.Add 添加实体
    //四.Update 编辑实体（这里的编辑是根据Id编辑所有信息，只作为基础功能，大多情况的编辑需要另外编写）
    //五.Dels 删除实体（兼容了批量删除）
    //也就是说，每生成一个实体类，接口层里都应有对应该实体类的这五个基本功能。
    public interface IStudent
    {
        #region base
        TableModel<Student> GetPageList(int pageIndex,int pageSize);
        /// <summary>
        /// 获取单个实体对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Student Get(long id);
        /// <summary>
        /// 添加单个实体对象
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        bool Add(Student student);
        /// <summary>
        /// 更新单个实体对象
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        bool Update(Student student);
        /// <summary>
        /// 删除单个实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Delete(long id);
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool DelMore(dynamic[] id);
        #endregion
    }
}
