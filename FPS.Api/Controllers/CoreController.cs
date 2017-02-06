using HelperFoundation.ErrorHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FPS.Api.Controllers
{
    public class CoreController : ApiController
    {
        [AcceptVerbs("GET", "POST")]
        public HttpResponseMessage GetApiStatus()
        {
            return Request.CreateResponse(new { Status= "Working", Message = "API is OK" });
        }

        protected HttpResponseMessage GenerateResponse(ProcessResult result)
        {
            if (result.Success)
            {
                return Request.CreateResponse(HttpStatusCode.OK, result.Message);
            }
            else
            {
                return Request.CreateResponse(result.StatusCode, result.ToString());
            }
        }

        protected HttpResponseMessage GenerateResponse<T>(ProcessResult<T> result)
        {
            if (result.Success)
            {
                return Request.CreateResponse(HttpStatusCode.OK, result.Result);
            }
            else
            {
                return Request.CreateResponse(result.StatusCode, result.ToString());
            }
        }
    }
}
