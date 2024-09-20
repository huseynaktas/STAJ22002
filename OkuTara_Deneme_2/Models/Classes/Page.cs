using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OkuTara_Deneme_2.Models.Classes
{
    public class Page
    {
        [Key]
        public int PageId { get; set; }

        [Column(TypeName = "Varchar")] 
        [StringLength(150)]
        public string PageTitle { get; set; }

        [Column(TypeName = "Varchar")] 
        [StringLength(5000)]
        public string PageContent { get; set; }

        [Column(TypeName = "Varchar")] 
        [StringLength(100)]
        public string PageName { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string PagePhoto { get; set; }

        public AdminPages Section { get; set; }
    }
}