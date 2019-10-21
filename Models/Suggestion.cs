using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoFocus_CodeFirst.Models
{
    public class Suggestion
    {   
        [Required]
        public int Id { get; set; }

        [Required]
        public String CustomerId { get; set; }

        [Required]
        [DisplayName("Subject")]
        public String FromName { get; set; }

        [Required]
        [DisplayName("To")]
        public String FromEmail { get; set; }

        [Required]
        [AllowHtml]
        public String EmailMessage { get; set; }


        public Customer Customers { get; set; }




    }
}