using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

public static class ApiHelper
{
    public static HttpResponseException CreateExceptionResponse(HttpStatusCode statusCode, string content)
    {
        return new HttpResponseException(new HttpResponseMessage(statusCode)
        {
            ReasonPhrase = content,
            Content = new StringContent(content)
        });
    }
    public static HttpResponseMessage CreateStringResponseMessage(HttpStatusCode statusCode, string content)
    {
        return new HttpResponseMessage(statusCode)
        {
            Content = new StringContent(content)
        };
    }
}