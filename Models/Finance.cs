using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace teamfb.Models
{
    public class Finance
    {
        public Finance(int BusinessAcountID,string UserName, int Quantity, DateTime date, string type, string desc, int bal)
        {
            this.BusinessAcountID = BusinessAcountID;
            this.UserName = UserName;
            this.Quantity = Quantity;
            this.Balance = bal;
            this.Description = desc;
            this.ItemType = type;
            this.DateOfTransaction = date;
        }
        public Finance()
        {

        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_column { get; set; }
        [Required]
        public int BusinessAcountID { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public DateTime DateOfTransaction { get; set; }
        [Required]
        public string ItemType { get; set;}
        [Required]
        public string Description { get; set; }
        [Required]
        public int Balance { get; set; }

    }
}