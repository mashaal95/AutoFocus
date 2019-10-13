using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoFocus_CodeFirst.Models
{
    public class Car
    {

        public Int32 CarId { get; set; }

        public Int32 BranchId { get; set; }

        public String CarName { get; set; }

        public String CarDesc { get; set; }

        public Int32 PricePerDay { get; set; }

        public Int32 NoOfSeats { get; set; }

        public String Transmission { get; set; }

        public ICollection<Rent> Rents { get; set; }

        public Branch Branches { get; set; }

    }
}