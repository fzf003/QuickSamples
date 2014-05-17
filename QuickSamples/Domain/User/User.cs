using QuickFramework.Caching;
using QuickFramework.DomainBase;
using QuickSamples.EventHandler.Events;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;

namespace QuickSamples.Domain
{
    public class User : AggregateRoot
    {
        public User()
            : base(null)
        {
            this.Id = this.Key;
        }

        public User(string id, string username, string password, string email,
            bool isdisabled, string registered, string lastdate, string contact, string phone)
            : base(id)
        {
            

            this.PublishAndApplyEvent(new CreateUserEvent
                (id,username,password,email,isdisabled,registered,lastdate,contact,phone));

         }


        public virtual string Id
        {
            get;
            set;
        }
        
       // public virtual string UserId { get; set; }

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
 

   

        public virtual void ChangeUserName(string userName)
        {
 
            this.PublishAndApplyEvent(new ChangeUserNameEvent(Id, userName));

        }

        protected void ApplyChange(ChangeUserNameEvent @event)
        {
             this.UserName = @event.UserName;
             
        }

        protected void ApplyChange(CreateUserEvent @event)
        {
            Console.WriteLine("扫行");
            this.Id = @event.Id;
            this.UserName = @event.UserName;
            this.Password = @event.Password;
            this.Email = @event.Email;
            this.IsDisabled = @event.IsDisabled;
            this.DateRegistered = @event.DateRegistered;
            this.Contact = @event.Contact;
            this.PhoneNumber = @event.PhoneNumber;
            this.LastDateTime = @event.LastDateTime;
        }


      
    }
}
