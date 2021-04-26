using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace teamfb.Models
{
    public class ClientModal
    {
        [Required]
        public string FullName { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string Phone { get; set;}
        [Required]
        public string Email { get; set; }
    }
}