using RayPI.Entity;
using RayPI.IService;
using RayPI.Model;
using RayPI.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace RayPI.Bussiness.Admin
{
    public class StudentBLL
    {
        private IStudent IStudent = new StudentService();
        public MessageModel<Student> Add(Student student)
        {
            if (IStudent.Add(student))
            {
                return new MessageModel<Student> { Success = true, Msg = "操作成功" };
            }
            else {
                return new MessageModel<Student> { Success = false, Msg = "操作失败" };
            }
            
        }

        public MessageModel<Student> Delete(long id)
        {
            if (IStudent.Delete(id))
            {
                return new MessageModel<Student> { Success = true, Msg = "操作成功" };
            }
            else
            {
                return new MessageModel<Student> { Success = false, Msg = "操作失败" };
            }
        }

        public MessageModel<Student> DelMore(dynamic[] id)
        {
            if (IStudent.DelMore(id))
            {
                return new MessageModel<Student> { Success = true, Msg = "操作成功" };
            }
            else
            {
                return new MessageModel<Student> { Success = false, Msg = "操作失败" };
            }
        }

        public Student GetById(long id)
        {
            return IStudent.Get(id);
        }

        public TableModel<Student> GetPageList(int pageIndex, int pageSize)
        {
          
            return IStudent.GetPageList(pageIndex, pageSize);
        }

        public MessageModel<Student> Update(Student student)
        {
            if (IStudent.Update(student))
            {
                return new MessageModel<Student> { Success = true, Msg = "操作成功" };
            }
            else
            {
                return new MessageModel<Student> { Success = false, Msg = "操作失败" };
            }
        }
    }
}
