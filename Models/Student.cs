using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentAP.Models
{
    public class Student
    {
        public Int64 ID { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int Maths { get; set; }

        public int English { get; set; }

        public int Science { get; set; }


    }
}