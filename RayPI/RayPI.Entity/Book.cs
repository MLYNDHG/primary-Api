using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Models
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("Book")]
    public partial class Book
    {
            /// <summary>
            /// 构造函数
            /// </summary>
           public Book(){


           }
           /// <summary>
           /// Desc:书籍编号
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true,IsIdentity=true)]
           public int Bookid {get;set;}

           /// <summary>
           /// Desc:书籍名称
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string Bookname {get;set;}

    }
}
