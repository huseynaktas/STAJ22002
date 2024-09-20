using OkuTara_Deneme_2.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OkuTara_Deneme_2.ViewModels
{
    public class ProfileRoleViewModel
    {
        public User User { get; set; }
        public List<Role> Role { get; set; }

    }
}