using QuickFramework.DomainBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickSamples.Domain
{
    public class Address : ValueObject<Address>
    {


        public Address() { }

        public Address(string country, string state)
        {
            this.Country = country;
            this.State = state;
        }

        /// <summary>
        /// 获取或设置“地址”类型中“国家”部分的信息。
        /// </summary>
        public virtual string Country
        {
            get;
            set;
        }
        /// <summary>
        /// 获取或设置“地址”类型中“省份/州”部分的信息。
        /// </summary>
        public virtual string State
        {
            get;
            set;
        }
    }
}
