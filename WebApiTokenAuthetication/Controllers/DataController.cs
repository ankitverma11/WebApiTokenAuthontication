using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace WebApiTokenAuthetication.Controllers
{
    public class DataController : ApiController
    {
        [AllowAnonymous]   // this action method is open for all type of user dont need to authonticate
        [HttpGet]
        [Route("api/data/forall")]
        public IHttpActionResult Get()
        {
            return Ok("Now server time is: " + DateTime.Now.ToString());
        }


        // this action for authonticated users if user is not authorized it will return 401
        [Authorize]
        [HttpGet]
        [Route("api/data/authenticate")]
        public IHttpActionResult GetForAuthenticate()
        {
            var identity = (ClaimsIdentity)User.Identity;
            return Ok("Hello " + identity.Name);
        }
        // to generate the token http://localhost:64162/token
        // authorized user only admin user can access this method
        [Authorize(Roles ="admin")]
        [HttpGet]
        [Route("api/data/authorize")]
        public IHttpActionResult GetForAdmin()
        {
            var identity = (ClaimsIdentity)User.Identity;
            var roles = identity.Claims
                       .Where(x => x.Type == ClaimTypes.Role)
                       .Select(x => x.Value);
            return Ok("hello " + identity.Name + "Role: " + string.Join(",", roles.ToList()));
        }

    }
}
