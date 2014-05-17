using QuickFramework.Bus.CommandBus;
using QuickFramework.Ioc;
using QuickFramework.Repository;
using QuickSamples.CommandHandler.Command;
using QuickSamples.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuickSamples.Common;

namespace QuickSamples.CommandHandler.Handler
{
   public class SaveUserCommandHandler:DefaultCommandHandler<SaveUserCommand>
    {
       

       public override void Handle(SaveUserCommand command)
       {
          
           var user1 = new User(command.UserId, command.UserName, command.Password, command.Email, false, DateTime.Now.ToString(), DateTime.Now.ToString(), command.Contact, command.PhoneNumber);

           
           WithIn.Change<User>(p =>
           {
               p.Save(user1);
               
           });
 
       }
    }

   public class ChangeUserNameCommandHandler : DefaultCommandHandler<ChangeUserNameCommand>
   {


       public override void Handle(ChangeUserNameCommand command)
       {

 

           WithIn.Change<User>(p =>
           {
               var user = p.FindById(command.UserId);
               user.ChangeUserName(command.UserName);

               p.Update(user);

           });

       }
   }
}
