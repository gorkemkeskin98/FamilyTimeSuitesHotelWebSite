using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyTimeSuites.Models
{
    public class OptionsModel
    {
        public string EmailHost { get; set; }
        public string EmailAccount { get; set; }
        public string EmailTo { get; set; }
        public int EmailPort { get; set; }
        public string EmailPassword { get; set; }
        public bool EmailSslEnable { get; set; }
    }
}
