using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Arbetsprov.Models
{
    public class Book
    {
        public string id { get; set; }
        public string title { get; set; }
        public string genre { get; set; }
        public string author { get; set; }
        public string price { get; set; }
        public string publish_date { get; set; }
        public string description { get; set; }

    }
}