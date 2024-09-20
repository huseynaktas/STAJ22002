using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OkuTara_Deneme_2.Models.Classes
{
    public class HomeSliderPhoto
    {
        [Key]
        public int PhotoId { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string PhotoUrl { get; set; }
    }
}