using Microsoft.EntityFrameworkCore.ChangeTracking;
using _2_Try.Datas;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
public class Program
{
    public static void Main()
    {
        // try
        //using (var context = new SchoolContext())
        //{
        //    retrieve entity
        //    var student = context.Students.FirstOrDefault();
        //    DisplayStates(context.ChangeTracker.Entries());
        //}
        var configuration = new ConfigurationBuilder()
    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .Build();


        //using (var context = new SchoolContext())
        //{
        //    context.Students.Add(new Student() { FirstName = "Bill", LastName = "Gates" });

        //    DisplayStates(context.ChangeTracker.Entries());
        //}

        //using (var context = new SchoolContext())
        //{
        //    var student = context.Students.FirstOrDefault();
        //    student.LastName = "Gates";

        //    DisplayStates(context.ChangeTracker.Entries());
        //}

        //using (var context = new SchoolContext())
        //{
        //    var student = context.Students.FirstOrDefault();
        //    context.Students.Remove(student);

        //    DisplayStates(context.ChangeTracker.Entries());
        //}

        //var disconnectedEntity = new Student() { StudentId = 1, FirstName = "Bill" };

        //using (var context = new SchoolContext())
        //{
        //    Console.Write(context.Entry(disconnectedEntity).State);
        //}


        ////---------------------------------------
        ////Veri EKLEME:

        using (var context = new SchoolContext())
        {
            var std2 = new Student()
            {
                FirstName = "Bill",
                LastName = "Gates",
                Weight = 72,
                Height = 1.77m
            };
            //context.Students.Add(std2);

            // or
            context.Add<Student>(std2);
            var v = context.SaveChanges();
        }


        ////VERI GUNCELLEME
        //using (var context = new SchoolContext())
        //{
        //    var std = context.Students.First<Student>();
        //    std.FirstName = "Steve";
        //    //context.SaveChanges();
        //}


        ////VERI SILME
        //using (var context = new SchoolContext())
        //{
        //    var std = context.Students.First<Student>();
        //    context.Students.Remove(std);

        //    // or
        //    // context.Remove<Student>(std);

        //    //context.SaveChanges();
        //}



        //-------------------------------------- 
        // QUERYING - SORGULAR
        var context1 = new SchoolContext();
        var studentsWithSameName = context1.Students
                                          .Where(s => s.FirstName == GetName())
                                          .ToList();



        // Include

        var context2 = new SchoolContext();

        var studentWithGrade = context2.Students
                                   .Where(s => s.FirstName == "Bill")
                                   .Include(s => s.Grade)
                                   .FirstOrDefault();


        //var context3 = new SchoolContext();

        //var studentWithGrade2 = context3.Students
        //                        .Where(s => s.FirstName == "Bill")
        //                        .Include("Grade")
        //                        .FirstOrDefault();

        //var context = new SchoolContext();

        //var studentWithGrade3 = context.Students
        //                        .FromSql("Select * from Students where FirstName ='Bill'")
        //                        .Include(s => s.Grade)
        //                        .FirstOrDefault();


        //Multiple Include

        var context4 = new SchoolContext();

        var studentWithGrade4 = context4.Students.Where(s => s.FirstName == "Bill")
                                .Include(s => s.Grade)
                                .Include(s => s.StudentCourses)
                                .FirstOrDefault();


        //Then Include 
        var context5 = new SchoolContext();

        var student = context5.Students.Where(s => s.FirstName == "Bill")
                                .Include(s => s.Grade)
                                    .ThenInclude(g => g.Teachers)
                                .FirstOrDefault();

        //Projection Querying
        var context6 = new SchoolContext();

        var stud = context6.Students.Where(s => s.FirstName == "Bill")
                                .Select(s => new
                                {
                                    Student = s,
                                    Grade = s.Grade,
                                    GradeTeachers = s.Grade.Teachers
                                })
                                .FirstOrDefault();


        //----------------------

        var std = new Student() { FirstName = "Bill" };

        using (var context = new SchoolContext())
        {
            //1. Attach an entity to context with Added EntityState
            context.Add<Student>(std);

            //or the followings are also valid
            // context.Students.Add(std);
            // context.Entry<Student>(std).State = EntityState.Added;
            // context.Attach<Student>(std);

            //2. Calling SaveChanges to insert a new record into Students table
            context.SaveChanges();
        }


        // Insert Relational Data - Ilişkisel Veri Ekleme

        var stdAddress = new StudentAddress()
        {
            City = "SFO",
            State = "CA",
            Country = "USA"
        };

        var std3 = new Student()
        {
            FirstName = "Steve",
            Address = stdAddress
        };
        using (var context = new SchoolContext())
        {
            // Attach an entity to DbContext with Added state
            context.Add<Student>(std3);

            // Calling SaveChanges to insert a new record into Students table
            context.SaveChanges();
        }
    }
    public static string GetName() //Querying Ekleme Icın
    {
        return "Bill";

    }

    static void DisplayStates(IEnumerable<EntityEntry> entries)
    {
        foreach (var entry in entries)
        {
            Console.WriteLine($"Entity: {entry.Entity.GetType().Name}, State: {entry.State.ToString()}");
        }
    }



}



//using _2_Try;

//using (var context = new SchoolContext())
//{
//    //creates db if not exists 
//    context.Database.EnsureCreated();

//    //create entity objects
//    var grd1 = new Grade() { GradeName = "1st Grade" };
//    var std1 = new Student() { FirstName = "Yash", LastName = "Malhotra", Grade = grd1 };

//    //add entitiy to the context
//    context.Students.Add(std1);

//    //save data to the database tables
//    context.SaveChanges();

//    //retrieve all the students from the database
//    foreach (var s in context.Students)
//    {
//        Console.WriteLine($"First Name: {s.FirstName}, Last Name: {s.LastName}");
//    }
//}