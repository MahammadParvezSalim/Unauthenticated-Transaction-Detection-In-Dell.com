using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebTracker.Models
{
    public class UserInfo
    {
        public string MCMID { get; set; }
        public string sessionID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string EmailAddress { get; set; }
        public string TimeStamp { get; set; }
    }
}