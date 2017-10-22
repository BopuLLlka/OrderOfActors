using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OrderOfStars.Models
{
    [Table("Orders")]
    public class OrderModel
    {
        [Key]
        public int Id { get; set; }
        public int StarId { get; set; }
        public string City { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
    }
}