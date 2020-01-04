using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WebTracker.Models;

namespace WebTracker.Controllers
{
    [EnableCors(origins: "https://www.dell.com", headers: "*", methods: "*")]
    public class CheckOutPageController : ApiController
    {
        // POST api/<controller>
        public void Post([FromBody]CheckoutPage page)
        {
            try
            {
                Ultility.UtilityCheckOutPage.LogCheckOutPageInfo(page);

        
            }
            catch (Exception ex)
            {
                //TODO log appliation error here
            }

        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]CheckoutPage page)
        {
            try
            {
                Ultility.UtilityCheckOutPage.LogCheckOutPageInfo(page);
            }
            catch (Exception ex)
            {
                //TODO log appliation error here
            }

        }

    }
}
