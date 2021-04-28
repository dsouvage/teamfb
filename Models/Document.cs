using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace teamfb.Models
{
    public class Document
    {   
        [Key]
        public string name { get; set; }
        [Required]
        public byte[] data { get; set; }
        [Required]
        public int BusinessAcountID { get; set; }
    }
}
