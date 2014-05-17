using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;
using QuickFramework.Bus.CommandBus;
using QuickFramework.Bus.CommandBus.Impl;
using QuickFramework.Bus.EventBus;
using QuickFramework.Bus.EventBus.Impl;

namespace QuickSamples.Module
{
    public class SystemModule : Autofac.Module
    {
        protected override void Load(Autofac.ContainerBuilder builder)
        {
            builder.Register<ICommandBus>(p => DefaultCommandBus.Instance).SingleInstance();

            builder.Register<IEventBus>(p => DefaultEventBus.Instance).SingleInstance();

        }
    }
}
