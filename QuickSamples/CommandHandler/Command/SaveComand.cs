using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickSamples.CommandHandler.Command
{
    public class SaveUserCommand
    {
        public string UserId { get; set; }

        public string Email { get; set; }

        public string UserName { get; set; }

        public bool IsSuccess { get; set; }

        public  string Contact { get; set; }
        public string Password { get; set; }
        /// <summary>
        /// 手机号码
        /// </summary>

        public  string PhoneNumber { get; set; }

        public SaveUserCommand(string userid, string pass,string username, string email,string contact,string phone)
        {

            this.Email = email;

            this.UserId = userid;
            this.Password = pass;

            this.UserName = username;
            this.Contact = contact;
            this.PhoneNumber = phone;
        }
    }
}
