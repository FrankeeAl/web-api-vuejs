using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SharpDevelopWebApi.Models
{
    public class Course
    {
        [Key] 
        public string Id { get; set; }

        public string Name { get; set; }
    }
}