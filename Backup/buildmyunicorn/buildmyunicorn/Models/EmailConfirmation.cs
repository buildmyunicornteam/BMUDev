using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace buildmyunicorn.Models
{
    public class EmailConfirmation
    {
        public Guid id { get; set; }
        public int CustomerID { get; set; }
        public bool LinkUsed { get; set; }
        public DateTime ConfirmationDate { get; set; }
        public DateTime ConfirmationExpiryDate { get; set; }
    }
}