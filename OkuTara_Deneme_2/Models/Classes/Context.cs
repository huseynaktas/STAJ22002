using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace OkuTara_Deneme_2.Models.Classes
{
    public class Context: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<QRCode> QRCodes { get; set; }
        public DbSet<QRCodeContent> QRCodeContents { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserInRole> UserInRoles { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<GeneralSetting> GeneralSettings { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<HomeSliderPhoto> HomeSliderPhotos { get; set; }
    }
}