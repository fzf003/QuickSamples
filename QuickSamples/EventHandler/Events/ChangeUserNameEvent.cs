using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickSamples.EventHandler.Events
{
    public class ChangeUserNameEvent:EventArgs
    {
        public string UserId { get; set; }

        public string UserName { get; set; }

        public ChangeUserNameEvent(string userid,string username)
        {
            this.UserId = userid;
            this.UserName = username;
        }
    }
}
