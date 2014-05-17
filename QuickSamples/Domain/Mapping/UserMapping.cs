using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickSamples.Domain.Mapping
{
    public class UserMapping:ClassMap<User>
    {
        public UserMapping()
        {
            this.Id(p => p.Id).GeneratedBy.Assigned();
            this.Map(p => p.UserName);
            this.Map(p => p.Password);
            this.Map(p => p.PhoneNumber);
            this.Map(p => p.LastDateTime);
            this.Map(p => p.IsDisabled);
            this.Map(p => p.DateRegistered);
            this.Map(p => p.Contact);
 
        }
    }
}
