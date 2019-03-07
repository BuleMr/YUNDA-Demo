using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class RequestVO
    {
        /// <summary>
        /// XML数据内容
        /// </summary>
        public string xmldata { get; set; }
        /// <summary>
        /// 合作社区ID,由韵达给大客户提供
        /// </summary>
        public string partnerid { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string password { get; set; }
        /// <summary>
        /// 数据请求类型，如request=data；其中data表示下单，详细请见request字典表
        /// </summary>
        public string request { get; set; }
        /// <summary>
        /// 请求的版本,当前版本为1.0
        /// </summary>
        public string version { get; set; }
    }
}
