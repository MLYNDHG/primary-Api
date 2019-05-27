using System;
using System.Collections.Generic;
using System.Text;

namespace RayPI.Token.Model
{
    /// <summary>
    /// 令牌类
    /// </summary>
    public class TokenModel
    {

        public TokenModel() {
            Uid = 0;  //此处为什么设置为零
        }
        /// <summary>
        /// 用户id
        /// </summary>
        public long Uid { get; set; }
        /// <summary>
        /// 用户姓名
        /// </summary>
        public string Uname { get; set; }
        /// <summary>
        /// 手机
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        public string Icon { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        public string UNickname { get; set; }
        /// <summary>
        /// 身份
        /// </summary>
        public string Sub { get; set; }
    }
}
