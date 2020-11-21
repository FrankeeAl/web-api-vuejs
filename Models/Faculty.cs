using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SharpDevelopWebApi.Models
{
    public class Faculty : Person
    {
        public string SSSNumber { get; set; }
        public string Supervisor { get; set; }
    }
}