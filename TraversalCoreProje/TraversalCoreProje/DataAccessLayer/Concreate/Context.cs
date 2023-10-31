using EntityLayer.Concreate; // About buradan geliyor
using Microsoft.AspNetCore.Identity.EntityFrameworkCore; // IdentityDbContex Sınıfını kullanabilmek için bu kütüphaneyi ekliyoruz
using Microsoft.EntityFrameworkCore; // dbContext buradan geliyor
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concreate
{
    //DbContext sınıfından miras alacak bu DbContext ekleyince hata verdi baştan Microsof.EntityFrameworkCore seçince düzeldi buradan geliyor bu paket
    // Identity özelliklerini kullanabilmek için IdentityDbContex sınıfını mirasçı yaptık
    // AppUser ve APPRole onları burda tanımlamıyoruz otomatik kendi oluşturuyor database'de
    public class Context:IdentityDbContext<AppUser,AppRole,int>
    {

        // protected bu değere içinde bulunduğu class'lardan ve ondan türetilen diğer class'lardan erişilebilir demek public ve private birleşimi gibi düşünülebilir
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-B34VKQ7\\SQLEXPRESS01;database=TraversalDB;integrated security=true;");

        }

        // sql tablo adı olacak tabloları oluşturuyoruz DbSet ile sql tablolarıbunlar, bu tanımlamalar EntityLayerConcreat tarafından geliyor
        public DbSet<About> Abouts { get; set; }
        public DbSet<About2> About2s { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContactUs> ContactUses { get; set; }
        public DbSet<Destination> Destinations { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Feature2> Feature2s { get; set; }
        public DbSet<Guide> Guides { get; set; }
        public DbSet<NewsLetter> NewLetters { get; set; }
        public DbSet<SubAbout> SubAbouts { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<Account> Accounts { get; set; }



    }
}
