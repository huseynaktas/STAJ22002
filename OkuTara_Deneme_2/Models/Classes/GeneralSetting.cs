using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OkuTara_Deneme_2.Models.Classes
{
    public class GeneralSetting
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "Varchar")] 
        [StringLength(250)]
        public string Title { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(500)]
        public string Description { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(500)]
        public string Keywords { get; set; }

        public bool IsActive { get; set; }

        [StringLength(20)]
        public string FontSize { get; set; }      // Örnek: "16px", "1.2em"

        [StringLength(50)]
        public string FontColor { get; set; }     // Örnek: "#000000"

        [StringLength(300)]
        public string FontFamily { get; set; }    // Örnek: "Arial, sans-serif"

        [StringLength(50)]
        public string BackgroundColor { get; set; }  // Örnek: "#FFFFFF"

        [Column(TypeName = "nvarchar(max)")]
        public string LogoUrl { get; set; }           // Örnek: "/Content/images/logo.png"
    }
}