using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoFocus_CodeFirst.Models
{
    public class Branch
    {
        public Int32 BranchId { get; set; }

        public String BrName { get; set; }

        public String BrDesc { get; set; }

        public String BrAddress { get; set; }

        public String BrSuburb { get; set; }

        public String City { get; set; }

        public Int32 ZipCode { get; set; }

        public ICollection<Car> Cars { get; set; }


        
    }
}