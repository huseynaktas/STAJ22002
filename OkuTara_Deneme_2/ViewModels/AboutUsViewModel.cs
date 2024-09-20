using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OkuTara_Deneme_2.Models.Classes;

namespace OkuTara_Deneme_2.ViewModels
{
    public class AboutUsViewModel
    {
        public List<Employee> Employees { get; set; }
        public About AboutContent { get; set; }
    }
}