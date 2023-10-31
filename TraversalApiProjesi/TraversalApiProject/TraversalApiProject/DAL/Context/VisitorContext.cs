using Microsoft.EntityFrameworkCore; // DbContext sınıfını kullanabilmek için bu kütüphaneyi ekledik 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TraversalApiProject.DAL.Entities; // Visitor sınıfını kullanabilmek için bu kütüphaneyi ekledik

namespace TraversalApiProject.DAL.Context
{
    public class VisitorContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-B34VKQ7\\SQLEXPRESS01;initial catalog=TraversalDBApi; integrated security=true;");
        }
        public DbSet<Visitor> Visitors { get; set; }
    }
}
