using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickSamples.CommandHandler.Command
{
    public class ChangeUserNameCommand
    {
        public string UserId { get; set; }

        public string Email { get; set; }

        public string UserName { get; set; }
    }
}
