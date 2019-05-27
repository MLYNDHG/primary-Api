using System;
using System.Collections.Generic;
using System.Text;

namespace RayPI.Model
{
    /// <summary>
    /// TableModel也是一个返回类，用于格式化的向接口返回列表格式的数据。
    /// 我理解为工具类的作用
    /// 但是工具类又是什么呢?
    /// 当然是工具了....
    /// 数据载体
    /// </summary>
    public class TableModel<T>
    {
        /// <summary>
        /// 返回编码
        /// ???
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// 返回信息
        /// ???
        /// </summary>
        public string Msg { get; set; }
        /// <summary>
        /// 记录总数
        /// </summary>
        public int Count { get; set; }
        /// <summary>
        /// 返回数据集
        /// </summary>
        public List<T> Data { get; set; }
    }
}
