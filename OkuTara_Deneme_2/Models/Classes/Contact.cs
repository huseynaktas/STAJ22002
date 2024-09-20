using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OkuTara_Deneme_2.Models.Classes
{
    public class Contact
    {
        [Key]
        public int ContactId { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string ContactFullName { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string ContactMail { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string Subject { get; set; }  

        [Column(TypeName = "Varchar")]
        [StringLength(1000)]
        public string ContactContent { get; set; }

        public bool IsRead { get; set; }

        public DateTime TimeToSend { get; set; }
    }
}