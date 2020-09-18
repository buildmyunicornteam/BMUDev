using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace buildmyunicorn.Models
{
    public class ForgotPassword
    {
        public Guid id { get; set; }
        public int CustomerID { get; set; }
        public bool LinkUsed { get; set; }
        public DateTime ForgotDatetime { get; set; }
        public DateTime ForgotExpiryDatetime { get; set; }
     
    }
}