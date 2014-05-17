using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickSamples.EventHandler.Events
{
    public class CreateUserEvent:EventArgs
    {
        public CreateUserEvent(string id, string username, string password, string email,
            bool isdisabled, string registered, string lastdate, string contact, string phone)
        {
            this.Id = id;
            this.UserName = username;
            this.Password = password;
            this.Email = email;
            this.IsDisabled = isdisabled;
            this.DateRegistered = registered;
            this.LastDateTime = lastdate;
            this.Contact = contact;
            this.PhoneNumber = phone;
        }
        public string Id { get; set; }
        public string UserName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public bool IsDisabled { get; set; }

        public string DateRegistered { get; set; }
        public string Contact { get; set; }

        public string PhoneNumber { get; set; }

        public string LastDateTime { get; set; }

    }

 }
