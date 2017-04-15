using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Swashbuckle.Swagger.Annotations;

namespace ApiTestServer.Controllers
{
    /// <summary>
    /// Misc operations
    /// </summary>
    [RoutePrefix("api/misc")]
    public class MiscController : ApiController
    {
        /// <summary>
        /// Check if the server is available
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("IsServiceAvailable")]
        [SwaggerResponse(HttpStatusCode.NoContent)]
        [SwaggerResponse(HttpStatusCode.ServiceUnavailable)]
        public HttpResponseMessage GetIsServiceAvailable()
        {
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }

        /// <summary>
        /// Get the server's time (UTC)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("ServerTime")]
        [SwaggerResponse(HttpStatusCode.OK)]
        public DateTime GetServerTimeUtc()
        {
            return DateTime.UtcNow;
        }

        /// <summary>
        /// Message that cause an internal server error
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("WillCrashForSure")]
        [SwaggerResponse(HttpStatusCode.OK)]
        public HttpResponseMessage WillCrashForSure()
        {
            throw new Exception("Well, I guess that was to be expected...");
        }

        /// <summary>
        /// Message that will answer "Forbidden"
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("WillNotAllowYouToProceed")]
        [SwaggerResponse(HttpStatusCode.Forbidden)]
        public HttpResponseMessage WillNotAllowYouToProceed()
        {
            return ApiHelper.CreateStringResponseMessage(HttpStatusCode.Forbidden, "I don't want you to go there");
        }

        /// <summary>
        /// Get your IP address
        /// </summary>
        /// <returns></returns>
        [Route("WhatIsMyIp")]
        [HttpGet]
        [SwaggerResponse(HttpStatusCode.OK)]
        public HttpResponseMessage WhatIsMyIp()
        {
            var clientIp = string.Empty;
            var context = System.Web.HttpContext.Current;

            //try with HTTP_X_FORWARDED_FOR
            var httpFormardedFor = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (!string.IsNullOrEmpty(httpFormardedFor))
            {
                var addresses = httpFormardedFor.Split(',');
                if (addresses.Length != 0)
                {
                    clientIp = addresses[0];
                }
            }

            //try with REMOTE_ADDR
            if (string.IsNullOrEmpty(clientIp))
                clientIp = context.Request.ServerVariables["REMOTE_ADDR"];


            //we got it, let's format the answer
            if (clientIp == "::1")
                clientIp = "localhost";

            if (clientIp.Contains(":"))
                clientIp = clientIp.Split(':').First();

            return ApiHelper.CreateStringResponseMessage(HttpStatusCode.OK, clientIp);
        }
    }
}