using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartPhoneShop.Library
{
    public class MyMessage
    {
        public String Msg { get; set; }
        public String Type { get; set; }
        public MyMessage(string msg, string type)
        {
            this.Msg = msg;
            this.Type = type;
        }
    }
}