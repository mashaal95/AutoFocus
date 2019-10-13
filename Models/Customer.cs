using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AutoFocus_CodeFirst.Models
{
    public class Customer
    {

        public string CustomerId { get; set; }


        [Required(ErrorMessage = "This field cannot be blank, please enter a valid name")]
        [RegularExpression(@"^[\w\s-]+$", ErrorMessage = "No special characters allowed")]
        public string Name { get; set; }


        [Required(ErrorMessage = "This field cannot be blank, please enter a valid Surname")]
        [RegularExpression(@"^[\w\s-]+$", ErrorMessage = "No special characters allowed")]
        public string Surname { get; set; }

        
        
        [DisplayName("Date Of Birth")]
        public DateTime DateOfBirth { get; set; }

        
        [DisplayName("Registration Date")]
        public DateTime RegistrationDate { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [DisplayName("Phone Number")]   
        public int PhoneNum { get; set; }

        public ICollection<Rent> Rents { get; set; }



    }
}