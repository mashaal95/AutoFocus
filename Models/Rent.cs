using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoFocus_CodeFirst.Models
{
    public class Rent
    {

        public Int32 RentId { get; set; }

        public String CustomerId { get; set; }

        public Int32 CarId { get; set; }    

        public Int32 Rating { get; set; }

        public String RatingDesc { get; set; }

        public DateTime DateOfBooking { get; set; }

        public DateTime EndOfBooking { get; set; }

        public Double TotalRate { get; set; }

        public Customer Customer { get; set; }

        public Rent Rents { get; set; }



    }
}