using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace u21448567_HW05.Models
{
    public class Students
    {
        public int studentId { get; set; } //PK
        public string name { get; set; }
        public string surname { get; set; }
        public DateTime birthdate { get; set; }
        public string gender { get; set; }
        public string stdClass { get; set; } 
        public int point { get; set; }
    }
}