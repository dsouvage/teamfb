using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace teamfb.Models
{
    public class FinanceModal
    {
        [Required]
        public int Quantity { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string Type { get; set;}
        [Required]
        public string Description { get; set; }
        [Required]
        public int Balance { get; set; }


    }
}