using QuickFramework.Bus.EventBus;
using QuickFramework.Ioc;
using QuickSamples.CacheModel;
using QuickSamples.Domain;
using QuickSamples.EventHandler.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickSamples.EventHandler.Handler
{
    public class CrateUserEventHandler : DefaultEventHandler<CreateUserEvent>
    {
        public override void Handle(CreateUserEvent @event)
        { 

            var userdto=new UserDTO()
            {
                Id = @event.Id,
             UserName = @event.UserName,
            Password = @event.Password,
            Email = @event.Email,
            IsDisabled = @event.IsDisabled,
            DateRegistered = @event.DateRegistered,
            Contact = @event.Contact,
            PhoneNumber = @event.PhoneNumber,
            LastDateTime = @event.LastDateTime,
            };

            Console.WriteLine(" 执行时间");
            ObjectFactory.GetService<QuickFramework.Caching.ICacheRepository<string, UserDTO>>()
                .Save(userdto);
        }
    }
}
