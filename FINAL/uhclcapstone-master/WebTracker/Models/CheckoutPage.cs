using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
        namespace WebTracker.Models
{
    public class CheckoutPage
    {
        public string MCMID { get; set; }
        public string sessionID { get; set; }
        public string CreditNumber { get; set; }
        public string SecurityCode { get; set; }
        public int ExpiryMonth { get; set; }
        public int ExpiryYear { get; set; }
        public string TimeStamp { get; set; }
    }
}