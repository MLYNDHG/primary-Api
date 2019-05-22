using RayPI.Entity;
using RayPI.IService;
using RayPI.Model;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace RayPI.Service
{
    public class StudentService : IStudent
    {
        public SimpleClient<Student> sdb = new SimpleClient<Student>(BaseDB.GetClient());
        public bool Add(Student student)
        {
            return sdb.Insert(student);
        }

        public bool Delete(long id)
        {
            return sdb.DeleteById(id);
        }

        public bool DelMore(dynamic[] id)
        {
            bool b = sdb.DeleteByIds(id);
            return b;
        }

        public Student Get(long id)
        {
            return sdb.GetById(id);
        }

        public TableModel<Student> GetPageList(int pageIndex, int pageSize)
        {
            PageModel page = new PageModel() { PageIndex=pageIndex,PageSize=pageSize};
            Expression<Func<Student, bool>> ex = (it => 1 == 1);
            List<Student> data = sdb.GetPageList(ex,page);
            TableModel<Student> t = new TableModel<Student>();
            t.Code = 0;
            t.Count = page.PageCount;
            t.Data = data;
            t.Msg = "成功";
            return t;
        }

        public bool Update(Student student)
        {
            return sdb.Update(student);
        }
    }
}
