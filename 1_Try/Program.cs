using _1_Try.Data;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;

public class Program
{

    public static void Main()
    {
        var configuration = new ConfigurationBuilder()
    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .Build();

        using (var context = new SchoolContext())
        {

            // retrieve entity 
            var student = context.Students.FirstOrDefault();
            DisplayStates(context.ChangeTracker.Entries());
        }




        using (var context = new SchoolContext())
        {
            //creates db if not exists 
            context.Database.EnsureCreated();


            //create entity objects
            var grd1 = new Grade() { GradeName = "1st Grade" };
            var std1 = new Student() { FirstName = "Yash", LastName = "Malhotra", Grade = grd1 };

            //add entitiy to the context
            context.Students.Add(std1);

            //save data to the database tables
            context.SaveChanges();

            //retrieve all the students from the database
            foreach (var s in context.Students)
            {
                Console.WriteLine($"First Name: {s.FirstName}, Last Name: {s.LastName}");
            }
        }


        using (var context = new SchoolContext())
        {
            context.Students.Add(new Student() { FirstName = "Bill", LastName = "Gates" });

            DisplayStates(context.ChangeTracker.Entries());
        }

        using (var context = new SchoolContext())
        {
            var student = context.Students.FirstOrDefault();
            student.LastName = "Friss";

            DisplayStates(context.ChangeTracker.Entries());
        }

        using (var context = new SchoolContext())
        {
            var student = context.Students.FirstOrDefault();
            context.Students.Remove(student);

            DisplayStates(context.ChangeTracker.Entries());
        }

        var disconnectedEntity = new Student() { StudentId = 1, FirstName = "Bill" };

        using (var context = new SchoolContext())
        {
            Console.Write(context.Entry(disconnectedEntity).State);
        }
        /// Appsetting.json dosyasından önceki kısım.

        //using (var context = new SchoolDbContext(configuration))
        //{

        //}


        // Veri Ekleme Islemi:

        using (var context = new SchoolContext())
        {
            var std = new Student()
            {
                FirstName = "Bill",
                LastName = "Gates"
            };
            context.Students.Add(std);

            // or
            // context.Add<Student>(std);

            //context.SaveChanges();
        }


        // Veri Degistirme Islemi:
        using (var context = new SchoolContext())
        {
            var std = context.Students.First<Student>();
            std.FirstName = "Steve";
            context.SaveChanges();
        }

        // Veri Silme Islemi:
        using (var context = new SchoolContext())
        {
            var std = context.Students.First<Student>();
            context.Students.Remove(std);

            // or
            // context.Remove<Student>(std);

            context.SaveChanges();
        }
    }

    public static void DisplayStates(IEnumerable<EntityEntry> entries)
    {
        foreach (var entry in entries)
        {
            Console.WriteLine($"Entity: {entry.Entity.GetType().Name}," +
                $"State: {entry.State.ToString()}");
        }
    }


}



