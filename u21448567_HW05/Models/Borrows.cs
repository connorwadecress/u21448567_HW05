using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace u21448567_HW05.Models
{
    public class Borrows
    {
        public int borrowId { get; set; } //PK
        public int studentId { get; set; } //FK
        public int bookId { get; set; } //FK
        public DateTime takenDate { get; set; }
        public DateTime broughtDate { get; set; }

        public string Name { get; set; }
        public int Count { get; set; }
        public string borrowedBy { get; set; }


    }
}