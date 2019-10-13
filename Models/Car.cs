using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AutoFocus_CodeFirst.Models
{
    public class Car
    {

        public Int32 CarId { get; set; }

        public Int32 BranchId { get; set; }

        [Required(ErrorMessage = "This field cannot be blank, please enter a valid Car name")]
        [RegularExpression(@"^[\w\s-]+$", ErrorMessage = "No special characters allowed")]
        [DisplayName("Car Name")]
        public String CarName { get; set; }

        [Required(ErrorMessage = "This field cannot be blank, please enter a valid Car Description")]
        [RegularExpression(@"^[\w\s-]+$", ErrorMessage = "No special characters allowed")]
        [DisplayName("Car Description")]
        public String CarDesc { get; set; }

        [Required]
        [RegularExpression(@"^[\w\s-]+$", ErrorMessage = "No special characters allowed")]
        [Range(0, 200, ErrorMessage = "The daily rate can only be from 0-200")]
        public Int32 PricePerDay { get; set; }

        [Required]
        [RegularExpression(@"^[\w\s-]+$", ErrorMessage = "No special characters allowed")]
        [DisplayName("Number of Seats")]
        [Range(0, 20 , ErrorMessage = "The seats number can only be from 0-20")]
        public Int32 NoOfSeats { get; set; }

        [Required]
        [RegularExpression(@"^[\w\s-]+$", ErrorMessage = "No special characters allowed")]
        public String Transmission { get; set; }

        public ICollection<Rent> Rents { get; set; }

        public Branch Branches { get; set; }

    }
}