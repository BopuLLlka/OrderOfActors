using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public string Time { get; set; }
        public int Price { get; set; }
        public string AvatarPath { get; set; }
    }
}