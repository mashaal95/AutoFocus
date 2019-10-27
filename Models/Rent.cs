using Foolproof;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace AutoFocus_CodeFirst.Models
{
    public class Rent
    {

        public Int32 RentId { get; set; }

        public string CustomerIdFK { get; set; }

        public Int32 CarId { get; set; }    

       
        [Range(0, 5, ErrorMessage = "The rating can only be from 1-5 ")]
        public Int32 Rating { get; set; }

        [StringLength(128)]
        public String RatingDesc { get; set; }

        
        [DisplayName("Booking Start Date")]
        public DateTime DateOfBooking { get; set; }

        [GreaterThan("DateOfBooking", ErrorMessage = "Start of Booking cannot be greater than End of Booking Date")]
        [DisplayName("Booking End Date")]
        public DateTime EndOfBooking { get; set; }


        public Double TotalRate { get; set; }

        public Customer Customer { get; set; }

        public Car Cars{ get; set; }

        [DataContract]
        public class DataPoint
        {
            public DataPoint(string label, dynamic y)
            {
                this.Label = label;
                this.Y = y;
            }

            //Explicitly setting the name to be used while serializing to JSON.
            [DataMember(Name = "label")]
            public string Label = "";

            //Explicitly setting the name to be used while serializing to JSON.
            [DataMember(Name = "y")]
            public dynamic Y = null;
        }



    }
}