using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoFocus_CodeFirst.Models
{
    public class Customer
    {

        public string CustomerId { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public DateTime DateOfBirth { get; set; }

        public DateTime RegistrationDate { get; set; }

        public int PhoneNum { get; set; }

        public ICollection<Rent> Rents { get; set; }



    }
}