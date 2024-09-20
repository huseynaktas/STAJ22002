using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OkuTara_Deneme_2.Models.Classes
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string RoleName { get; set; }

        public bool RoleState { get; set; }

        public ICollection<UserInRole> UserInRoles { get; set; }
    }
}