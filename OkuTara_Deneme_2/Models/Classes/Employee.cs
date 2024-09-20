using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OkuTara_Deneme_2.Models.Classes
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(25)]
        public string EmployeeName { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(25)]
        public string EmployeeSurname { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string EmployeeDepartment { get; set; }


        [Column(TypeName = "nvarchar(max)")]
        public string EmployeeImage { get; set; }

    }
}