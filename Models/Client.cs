using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace teamfb.Models
{
 //   ID_column INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
 //   UserName varchar(255) NOT NULL,
 //   DateOfTransaction Date NOT NULL,
 //   FullName varchar(255) NOT NULL,
 //   Description varchar(255),
//    Phone varchar(255) NOT NULL,
 //   Email varchar(255) NOT NULL,
 //   BusinessAcountID int FOREIGN KEY REFERENCES[dbo].[UserAccounts] (BusinessAcountID)

    public class Client
    {
        public Client(int BusinessAcountID, string UserName, string FullName, DateTime date, string Phone, string desc, string email)
        {
            this.BusinessAcountID = BusinessAcountID;
            this.UserName = UserName;
            this.FullName = FullName;
            this.Email = email;
            this.Description = desc;
            this.Phone = Phone;
            this.DateOfTransaction = date;
        }
        public Client()
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
        public string FullName { get; set; }
        [Required]
        public DateTime DateOfTransaction { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Email { get; set; }

    }
}