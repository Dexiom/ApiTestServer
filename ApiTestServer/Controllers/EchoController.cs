using System;
using System.Net;
using System.Web.Http;
using Swashbuckle.Swagger.Annotations;
using ApiTestServer.Model;

namespace ApiTestServer.Controllers
{
    /// <summary>
    /// Simple test tool that repeat what it has received.
    /// </summary>
    [RoutePrefix("api/remote")]
    public class EchoController : ApiController
    {
        /// <summary>
        /// Get some random stuff
        /// </summary>
        /// <param name="param1">Some value</param>
        /// <param name="param2">Another value</param>
        /// <returns></returns>
        [SwaggerResponse(HttpStatusCode.OK)]
        public EchoOutputModel Get(string param1, string param2)
        {
            return new EchoOutputModel
            {
                Id = 123,
                Date = DateTime.Now,
                Message = "A simple test message",
                UrlQuery = Request.RequestUri.Query,
                Headers = Request.Headers
            };
        }

        /// <summary>
        /// Say something
        /// </summary>
        /// <returns></returns>
        [SwaggerResponse(HttpStatusCode.OK)]
        public EchoOutputModel Post(EchoInputModel model)
        {
            var retVal = new EchoOutputModel(model)
            {
                UrlQuery = Request.RequestUri.Query,
                Headers = Request.Headers
            };

            return retVal;
        }
    }
}