using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AutoFocus_CodeFirst.Models
{
    public class Branch
    {
        public Int32 BranchId { get; set; }

        [Required(ErrorMessage = "This field cannot be blank, please enter valid Branch name")]
        [RegularExpression(@"^[\w\s-]+$", ErrorMessage = "No special characters allowed")]
        [DisplayName("Branch Name")]
        public String BrName { get; set; }

        [Required(ErrorMessage = "This field cannot be blank, please enter valid Branch name")]
        [RegularExpression(@"^[\w\s-]+$", ErrorMessage = "No special characters allowed")]
        [DisplayName("Branch Description")]
        public String BrDesc { get; set; }

        [Required(ErrorMessage = "This field cannot be blank, please enter valid Branch Description")]
        [RegularExpression(@"^[\w\s-]+$", ErrorMessage = "No special characters allowed")]
        [DisplayName("Branch Address")]
        public String BrAddress { get; set; }

        [Required(ErrorMessage = "This field cannot be blank, please enter valid Branch name")]
        [RegularExpression(@"^[\w\s-]+$", ErrorMessage = "No special characters allowed")]
        [DisplayName("Branch Suburb")]
        public String BrSuburb { get; set; }

        [Required(ErrorMessage = "This field cannot be blank, please enter valid Branch name")]
        [RegularExpression(@"^[\w\s-]+$", ErrorMessage = "No special characters allowed")]
        public String City { get; set; }

        [Required]
        public Int32 ZipCode { get; set; }

        public ICollection<Car> Cars { get; set; }


        
    }
}