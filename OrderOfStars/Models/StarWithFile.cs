using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrderOfStars.Models
{
    public class StarWithFile
    {
        public Stars Stars { get; set; }
        public HttpPostedFile File { get; set; }
    }
}