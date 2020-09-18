using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuildMyUnicorn.Models
{
    public class Common
    {
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime CreateDateTime { get; set; }
        public DateTime ModifiedDateTime { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
      

    }
}