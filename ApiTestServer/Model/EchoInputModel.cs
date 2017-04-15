using System;

namespace ApiTestServer.Model
{
    /// <summary>
    /// A model that will be echoed
    /// </summary>
    public class EchoInputModel : IEchoModel
    {
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
    }
}