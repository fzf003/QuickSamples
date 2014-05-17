using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickSamples.CacheModel
{
    public class UserDTO:QuickFramework.Caching.ICacheEntity<string>
    {
 
        public virtual string Id
        {
            get;
            set;
        }

 
        public virtual string UserName { get; set; }

        public virtual string Password { get; set; }

        public virtual string Email { get; set; }
        /// <summary>
        /// 是否禁用
        /// </summary>
        public virtual bool IsDisabled { get; set; }
        /// <summary>
        /// 注册时间
        /// </summary>
        public virtual string DateRegistered { get; set; }
        /// <summary>
        /// 最后登录时间
        /// </summary>
        public virtual string LastDateTime { get; set; }
        /// <summiary>
        /// 联系人
        /// </summary>
        public virtual string Contact { get; set; }
        /// <summary>
        /// 手机号码
        /// </summary>

        public virtual string PhoneNumber { get; set; }


 


    }
}
