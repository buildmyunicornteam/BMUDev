using System;
using BuildMyUnicorn.Models;

namespace BuildMyUnicorn.Models
{
    public class Client : Common
    {
        public int ClientID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public int CountryID { get; set; }
        public Guid ConfirmationID { get; set; }
        public DateTime LastLoginDateTime { get; set; }
    }
}