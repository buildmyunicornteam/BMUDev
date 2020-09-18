using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace buildmyunicorn.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public int CountryID { get; set; }
        public int TimeZoneID { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public Guid ConfirmationID { get; set; }
    }
}