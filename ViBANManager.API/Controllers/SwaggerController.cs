using System.Net.Http;
using System.Net;
using System;
using System.Web.Http;

namespace ViBANManager.API.Controllers
{
    public class SwaggerController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage Index()
        {
            var response = Request.CreateResponse(HttpStatusCode.Redirect);
            response.Headers.Location = new Uri("/swagger/ui/index", UriKind.Relative);
            return response;
        }
    }
}
