using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrderOfStars.Models
{
    public class OrderModel
    {
        public int StarId { get; set; }
        public string City { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public int Price { get; set; }
    }
}