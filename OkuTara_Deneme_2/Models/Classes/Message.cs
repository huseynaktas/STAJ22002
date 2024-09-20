using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OkuTara_Deneme_2.Models.Classes
{
    public class Message
    {
        public int MessageId { get; set; }
        public string MessageContent { get; set; }
        public DateTime MessageDate { get; set; }


        public int UserId { get; set; }
        public virtual User User { get; set; }

    }
}