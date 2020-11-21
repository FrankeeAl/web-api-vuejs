using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SharpDevelopWebApi.Models
{
    public class StudentGrade
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public double P1Grade { get; set; }
        public double P2Grade { get; set; }
        public double P3Grade { get; set; }
    }
}