using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace StudentAP.Models
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext() : base("StudentDbConStr") {

        }

        public DbSet<Student> Students { get; set; }
    }
}