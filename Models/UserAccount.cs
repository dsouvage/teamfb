using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace teamfb.Models
{
    public class UserAccount
    {
        [Key,Required]
        public int BusinessAcountID { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        public DateTime DateCreated { get; set; }

    }
}