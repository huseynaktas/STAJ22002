using OkuTara_Deneme_2.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OkuTara_Deneme_2.ViewModels
{
    public class MessageViewModel
    {
        public QRCodeContent QRContent { get; set; }
        public Message Message { get; set; }
    }
}