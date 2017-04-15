using System;
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
    }
}