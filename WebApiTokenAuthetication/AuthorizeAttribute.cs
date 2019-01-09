using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace WebApiTokenAuthetication
{
    public class AuthorizeAttribute: System.Web.Http.AuthorizeAttribute
    {
        // here we will handled Unauthorized request 

        protected override void HandleUnauthorizedRequest(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                base.HandleUnauthorizedRequest(actionContext);
            }
            else
            {
                HttpRequestMessage request = new HttpRequestMessage();
                actionContext.Response = request.CreateResponse(System.Net.HttpStatusCode.Forbidden);
            }
        }

    }
}