using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OkuTara_Deneme_2.Models.Classes
{
    public class QRCodeContent
    {
        [Key]
        public int QRContentId { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(500)]
        public string GeneralMessage { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string InstagramUrl { get; set; }
        public bool InstagramState { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string FacebookUrl { get; set; }
        public bool FacebookState { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string XUrl { get; set; }
        public bool XState { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string WhatsappUrl { get; set; }
        public bool WhatsappState { get; set; }


        public int UserId { get; set; }
        public virtual User User { get; set; }

        public int QRCodeId { get; set; }
        public virtual QRCode QRCode { get; set; }
    }
}