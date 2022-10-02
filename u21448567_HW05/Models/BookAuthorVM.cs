using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace u21448567_HW05.Models
{
    public class BookAuthorVM
    {
        private long baID;
        public List<Books> Books { get; set; }
        public List<Authors> Authors { get; set; }


    }
}