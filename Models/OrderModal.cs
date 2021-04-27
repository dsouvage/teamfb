using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace teamfb.Models
{
    public class OrderModal
    {
        [Required]
        public int Quantity { get; set; }
        [Required]
        public DateTime DateOfTransaction { get; set; }
        [Required]
        public DateTime DateOrderDue { get; set; }
        [Required]
        public string ItemType { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string ClientEmail { get; set; }

    }
}