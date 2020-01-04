using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebTracker.Models
{
    public class VisitedPage
    {
        public string MCMID { get; set; }
        public string sessionID { get; set; }
        public string pathName { get; set; }
        public string url { get; set; }
        public string referer { get; set; }
        public DateTime? startDateTime { get; set; }
        public DateTime? endDateTime { get; set; }
    }
}