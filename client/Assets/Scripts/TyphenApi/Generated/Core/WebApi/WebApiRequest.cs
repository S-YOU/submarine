﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace TyphenApi
{
    public enum HttpMethod
    {
        Get,
        Post,
        Put,
        Delete
    }

    public interface IWebApiRequest
    {
        Uri Uri { get; set; }
        HttpMethod Method { get; set; }
        Dictionary<string, string> Headers { get; set; }
        bool NoAuthenticationRequired { get; set; }
        TypeBase Body { get; }
        byte[] BodyBytes { get; }
        bool HasSent { get; }

        void OnSendComplete(Dictionary<string, string> headers, byte[] bytes, string errorText);
    }

    public partial class WebApiRequest<ResponseT, ErrorT> : IWebApiRequest
        where ResponseT : TypeBase, new()
        where ErrorT : TypeBase, new()
    {
        readonly IWebApiController<ErrorT> controller;
        readonly IWebApiRequestSender sender;
        readonly ISerializer serializer;
        IEnumerator sendingRoutine;

        public Uri Uri { get; set; }
        public HttpMethod Method { get; set; }
        public Dictionary<string, string> Headers { get; set; }
        public bool NoAuthenticationRequired { get; set; }
        public TypeBase Body { get; set; }
        public byte[] BodyBytes { get { return serializer.Serialize(Body); } }
        public bool HasSent { get { return sendingRoutine != null; } }

        public WebApiResponse<ResponseT> Response { get; private set; }
        public WebApiError<ErrorT> Error { get; private set; }

        public WebApiRequest(IWebApiController<ErrorT> controller,
            IWebApiRequestSender sender, ISerializer serializer)
        {
            Headers = new Dictionary<string, string>();
            this.controller = controller;
            this.sender = sender;
            this.serializer = serializer;
        }

        public WebApiRequest<ResponseT, ErrorT> Set(string headerName, string headerValue)
        {
            Headers[headerName] = headerValue;
            return this;
        }

        public IEnumerator SendAsync()
        {
            if (HasSent)
            {
                return sendingRoutine;
            }
            else
            {
                controller.OnBeforeRequestSend(this);
                sendingRoutine = sender.Send(this);
                return sendingRoutine;
            }
        }

        public void OnSendComplete(Dictionary<string, string> headers, byte[] bytes, string errorText)
        {
            if (string.IsNullOrEmpty(errorText))
            {
                try
                {
                    var response = serializer.Deserialize<ResponseT>(bytes);
                    Response = new WebApiResponse<ResponseT>(headers, response);
                }
                catch (SerializationError)
                {
                    Error = new WebApiError<ErrorT>(headers, null, bytes, "Failed to deserialize a response");
                }
            }
            else
            {
                try
                {
                    var error = serializer.Deserialize<ErrorT>(bytes);
                    Error = new WebApiError<ErrorT>(headers, error, bytes, errorText);
                }
                catch (SerializationError)
                {
                    Error = new WebApiError<ErrorT>(headers, null, bytes, errorText);
                }
            }

            if (Error == null)
            {
                controller.OnRequestSuccess(this, Response);
            }
            else if (Error.Error != null)
            {
                controller.OnRequestError(Error);
            }
        }
    }
}
