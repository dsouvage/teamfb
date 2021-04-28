using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Http;


namespace teamfb.Models
{
    public class DocumentModal
    {
        [Required]
        public HttpPostedFileBase Data { get; set; }
    }
}