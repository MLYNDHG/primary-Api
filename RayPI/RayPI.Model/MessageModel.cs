using System;
using System.Collections.Generic;
using System.Text;

namespace RayPI.Model
{
    /// <summary>
    /// 通用返回信息类
    /// MessageModel是一个泛型的返回类，用于格式化的向接口返回数据。
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MessageModel<T>
    {
        /// <summary>
        /// 操作是否成功
        /// </summary>
        public bool Success { get; set; }
        /// <summary>
        /// 返回信息
        /// </summary>
        public string Msg { get; set; }
        /// <summary>
        /// 返回数据集合
        /// </summary>
        public List<T> Data { get; set; }
    }
}
