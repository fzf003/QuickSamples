using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickSamples.Domain
{
    public class Order
    {
        public virtual string OrderId
        {
            get;
            set;
        }

        public virtual string OrderName
        {
            get;
            set;
        }

        public virtual OrderState OrderState
        {
            get;
            set;
        }
    }
}
