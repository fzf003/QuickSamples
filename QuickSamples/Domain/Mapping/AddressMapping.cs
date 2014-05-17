using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickSamples.Domain.Mapping
{
    public class AddressMapping:FluentNHibernate.Mapping.ComponentMap<Address>
    {
        public AddressMapping()
        {
            this.Map(p => p.Country);
            this.Map(p => p.State);
        }
    }
}
