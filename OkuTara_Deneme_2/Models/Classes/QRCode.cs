using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OkuTara_Deneme_2.Models.Classes
{
    public class QRCode
    {
        [Key]
        public int QRId { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string QRCodeData { get; set; }

        public DateTime? QRCodeDate { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }

        public ICollection<QRCodeContent> QRCodeContents { get; set; }

    }
}