using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using _2_Try.Datas;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_Try.Datas
{
    public class SchoolContext : DbContext
    {
        //IConfiguration appConfig;
        public DbSet<Student> Students { get; set; }
        public DbSet<Grade> Grades { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);
        //}



        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=SchoolDb;Trusted_Connection=True;");
        //}
        //public SchoolContext(IConfiguration config)
        //{
        //    appConfig = config;
        //}

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(appConfig.GetConnectionString("SchoolDBLocalConnection");

        //}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable("SchoolDBLocalConnection"));
        }


    }
}


