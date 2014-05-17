using QuickFramework.Ioc;
using QuickSamples.CacheModel;
using QuickSamples.EventHandler.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickSamples.EventHandler.Handler
{
    public class ChaneUserNameEventHandler : QuickFramework.Bus.EventBus.DefaultEventHandler<ChangeUserNameEvent>
    {
        public override void Handle(ChangeUserNameEvent @event)
        {

            var repository = ObjectFactory.GetService<QuickFramework.Caching.ICacheRepository<string, UserDTO>>();

            var dto =repository.GetById(@event.UserId);
            dto.UserName = @event.UserName;

            repository.Update(dto);

        }
    }
}
