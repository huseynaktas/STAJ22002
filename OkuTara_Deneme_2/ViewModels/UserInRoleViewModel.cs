using OkuTara_Deneme_2.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OkuTara_Deneme_2.ViewModels
{
    public class UserInRoleViewModel
    {
        public User User { get; set; }
        public Role Role { get; set; }
        public UserInRole UserInRole { get; set; }
    }
}