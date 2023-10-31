using Microsoft.EntityFrameworkCore; // DbContext sınıfını kullanabilmek için bu kütüphaneyi ekledik
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRApi.DAL
{
    public class Context:DbContext
    {

       
        public Context(DbContextOptions<Context> options):base(options)
        {

        }

        public DbSet<VisitorCity> VisitorCities { get; set; }
        
    }
}
