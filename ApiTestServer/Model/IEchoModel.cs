using System;

namespace ApiTestServer.Model
{
    public interface IEchoModel
    {
        DateTime Date { get; set; }
        int Id { get; set; }
        string Message { get; set; }
    }
}