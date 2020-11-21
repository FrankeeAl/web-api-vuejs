using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SharpDevelopWebApi.Models
{
    public class Subject
    {
        public int Id { get; set; }
        public string Code { get; set; } //ITE-308,ITE-301
        public string DescriptiveTitle { get; set; }
    }
}