using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SharpDevelopWebApi.Models
{
    public class Student : Person
    {
        public string SchoolLastAttended { get; set; }
        public string CourseId { get; set; }
    }
}