using LanguageCoursesWebApp.Models;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LanguageCoursesWebApp.Data
{
    public class AppContext : DbContext
    {
        public AppContext() : base("name=LanguageConnectionString") { }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Listener> Listeners { get; set; }
        public DbSet<Payment> Payments { get; set; }
    }
}
