using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OkuTara_Deneme_2.Models.Classes
{
    public class About
    {
        [Key]
        public int AboutId { get; set; }

        [AllowHtml]  // HTML içerikli veri kabul edilecek
        [Column(TypeName = "nvarchar(max)")]
        public string AboutContent { get; set; }
    }
}