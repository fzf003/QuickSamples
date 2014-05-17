using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuickFramework.Autofac;
using Autofac;
using QuickFramework.Log4Net;
using log4net;
using System.Reflection;
using QuickFramework.Ioc;
using NHibernate;
using QuickSamples.Common;
using QuickFramework.Repository;
using QuickSamples.Domain;
using QuickFramework.Bus.CommandBus;
using QuickSamples.CommandHandler.Command;
using QuickSamples.Common.Validator;
namespace QuickSamples
{
    [TestFixture]
    public class TestCase1
    {
        [SetUp]
        public void Init()
        {
            QuickFramework.Configuration.Create()
               .UseAutoFac((cfg) =>
               {
                   cfg.RegisterModule<Module.SystemModule>();
                   cfg.RegisterModule<Module.PersistenceModule>();
                })
               .RegisterCommandHandler(Assembly.GetExecutingAssembly())
               .RegisterEventHandler(Assembly.GetExecutingAssembly())
               .UseLog4Net()
               .Start();
        }

        [Test]
        public void CreateUserCommandValidator()
        {

              var savecommand = new SaveUserCommand(Guid.NewGuid().ToString(), "fzf003", "fzf0033", "280086260@163.com", "中国", "192003992");
 

                ObjectFactory.GetService<ICommandBus>()
                 .SendCommand<SaveUserCommand>(savecommand);
           

        
         }


        [Test]
        public void ChangeName()
        {
            //User userinfo = new User();
            ////02a3b505-5a55-4124-8174-8e0b0723f1aa
            //WithIn.Change<User>((user) => {
            //   userinfo= user.FindById("02a3b505-5a55-4124-8174-8e0b0723f1aa");
            //});

            ObjectFactory.GetService<ICommandBus>()
                .SendCommand<ChangeUserNameCommand>(new ChangeUserNameCommand() {
                    UserId = "02a3b505-5a55-4124-8174-8e0b0723f1aa",
                     UserName="小美"
                });
        }

        [TearDown]
        public void End()
        {
            ObjectFactory.GetService<ISessionFactory>().Dispose();
        }
    }
}