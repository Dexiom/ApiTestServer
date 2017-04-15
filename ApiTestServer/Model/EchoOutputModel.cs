using System;
using System.Net.Http.Headers;

namespace ApiTestServer.Model
{
    /// <summary>
    /// The echoed model
    /// </summary>
    public class EchoOutputModel : EchoInputModel
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public EchoOutputModel()
        {
        }

        /// <summary>
        /// Copy Constructor
        /// </summary>
        /// <param name="input">The object to be echoed</param>
        public EchoOutputModel(EchoInputModel input)
        {
            Id = input.Id;
            Date = input.Date;
            Message = input.Message;
        }

        /// <summary>
        /// Id is pretty common field, wouldn't you agree?
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Some random date
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// A nice message
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// The url query
        /// </summary>
        public string UrlQuery { get; set; }

        /// <summary>
        /// The header received with the message
        /// </summary>
        public HttpRequestHeaders Headers { get; set; }
    }
}