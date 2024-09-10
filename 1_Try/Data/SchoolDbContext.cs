using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_Try.Data
{
    public class SchoolContext : DbContext
    {
        IConfiguration appConfig;
        public DbSet<Student> Students { get; set; }
        public DbSet<Grade> Grades { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);
        //}

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=SchoolDb;Trusted_Connection=True;");
        //    //optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=SchoolDb;UserId=myuserid;Passwprd=mypwd;"); 
        //    //Eşleştirmeden önce bu şekilde.
        //}  //Appsetting.json dosyasından önce kullanılır. 

        //public class SchoolDbContext : DbContext
        //{

        //    IConfiguration appConfig;
        //    public DbSet<Student> Students { get; set; }
        //    public DbSet<Grade> Grades { get; set; }

        //public SchoolContext(IConfiguration config)
        //{
        //    appConfig = config;
        //}

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    //optionsBuilder.UseSqlServer(appConfig.GetConnectionString("SchoolDBLocalConnection");
        //    optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable("YourConnectionStringEnvVar"));



        //}




        //public static void Main()
        //{
        //    using (var context = new SchoolDbContext())
        //    {

        //        // retrieve entity 
        //        var student = context.Students.FirstOrDefault();
        //        DisplayStates(context.ChangeTracker.Entries());
        //    }
        //}

        //public static void DisplayStates(IEnumerable<EntityEntry> entries)
        //{
        //    foreach (var entry in entries)
        //    {
        //        Console.WriteLine($"Entity: {entry.Entity.GetType().Name}," +
        //            $"State: {entry.State.ToString()}");
        //    }
        //}


    }
}






//}
