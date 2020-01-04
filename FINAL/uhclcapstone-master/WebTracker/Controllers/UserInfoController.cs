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
    public class UserInfoController : ApiController
    {
        public void Post([FromBody]UserInfo userInfo)
        {
            try
            {
                Ultility.Ultility.LogUserInfo(userInfo);
            }
            catch (Exception ex)
            {
                //TODO log appliation error here
            }

        }

    }
}
