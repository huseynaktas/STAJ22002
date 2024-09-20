using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OkuTara_Deneme_2.Models.Classes
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string UserName { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string UserSurname { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string UserEmail { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string UserPassword { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string UserPhone { get; set; }

        public bool UserState { get; set; }

        public ICollection<QRCode> QRCodes { get; set; }

        public ICollection<QRCodeContent> QRCodeContents { get; set; }

        public ICollection<Message> Messages { get; set; }

        public ICollection<UserInRole> UserInRoles { get; set; }

    }
}