using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrderOfStars.Models
{
    public class Stars
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EMail { get; set; }
        public string Description { get; set; }
    }
}