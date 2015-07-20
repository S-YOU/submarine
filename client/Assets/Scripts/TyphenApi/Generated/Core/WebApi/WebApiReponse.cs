﻿using System.Collections.Generic;

namespace TyphenApi
{
    public interface IWebApiResponse
    {
        Dictionary<string,string> Headers { get; }
        TypeBase Body { get; }
    }

    public class WebApiResponse<T> : IWebApiResponse where T : TypeBase
    {
        public Dictionary<string, string> Headers { get; private set; }
        public TypeBase Body { get { return Data; } }

        public T Data { get; private set; }

        public WebApiResponse(Dictionary<string, string> headers, T response)
        {
            Headers = headers;
            Data = response;
        }
    }
}
