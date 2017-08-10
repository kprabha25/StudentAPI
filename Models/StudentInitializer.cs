using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace StudentAP.Models
{
    public class StudentInitializer : DropCreateDatabaseAlways<StudentDbContext>
    {
        protected override void Seed(StudentDbContext context)
        {
            var students = new List<Student>
            {
                new Student { Firstname = "Rahul", Lastname = "Karan", Maths = 60, English = 80, Science = 90  },
                new Student { Firstname = "Ravi", Lastname = "Kumar",  Maths = 70, English = 60, Science = 80   },
                new Student { Firstname = "Senthil", Lastname = "Raj",  Maths = 80, English = 70, Science = 60   },
            };
            students.ForEach(x => context.Students.Add(x));
            context.SaveChanges();
        }
    }
}