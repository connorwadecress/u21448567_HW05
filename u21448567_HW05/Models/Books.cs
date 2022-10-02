using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace u21448567_HW05.Models
{
    public class Books
    {
        public int bookId { get; set; } //PK
        public string name { get; set; }
        public int pagecount { get; set; }
        public int point { get; set; }
        public string authorId { get; set; } //FK
        public string typeId { get; set; } //FK





    }
}