using MainApp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace college_interview_task_v4
{
    public abstract class HttpRequestHandler<TRequest>
    {
        internal HttpClient _httpClientProxy;
        private IHttpResponseParser<TRequest> _parser { get; }

        protected HttpRequestHandler(HttpClient httpClientProxy, IHttpResponseParser<TRequest> parser)
        {
            _httpClientProxy = httpClientProxy;
            _parser = parser;
        }

        public async Task<TRequest> GetEntryAsync(object payload, string methodName, string Endpoint,
            IDictionary<string, string> additionalHeaders, CancellationToken cancellationToken)
        {
            var httpMethod = new HttpMethod(methodName);
            var uri = FullUriString(Endpoint);

            var httpRequestMessage = new HttpRequestMessage(httpMethod, uri);

            SetContentFromPayload(payload, ref httpRequestMessage);

            SetAdditionalHeaders(additionalHeaders, ref httpRequestMessage);

            HttpResponseMessage response = await _httpClientProxy.SendAsync(httpRequestMessage, cancellationToken);

            if (!response.IsSuccessStatusCode)
            {
                throw new EndOfStreamException(string.Join(",", response.Headers));
            }
            
            return ParseResponse(response);
        }

        private Uri FullUriString(string Endpoint)
        {
           return new Uri($"{_httpClientProxy.BaseAddress}{Endpoint}");
        }

        private void SetContentFromPayload(object payload, ref HttpRequestMessage httpRequestMessage) 
        {
            if (payload == null)
            {
                throw new HttpRequestException("Payload is null!");
            }
            else
            {
                httpRequestMessage.Content = payload as HttpContent;
            }
        }

        private void SetAdditionalHeaders(IDictionary<string, string> headers, ref HttpRequestMessage httpRequestMessage) 
        {
            if (headers == null)
            {
                throw new HttpRequestException("Headers are null!");
            }
            else
            {
                foreach (var header in headers)
                {
                    httpRequestMessage.Headers.Add(header.Key, header.Value);
                }
            }
        }

        private TRequest ParseResponse(HttpResponseMessage response) 
        {
            try
            {
                return _parser.ParseAsync(response);
            }
            catch (Exception ex)    
            {
                throw new FailedToParseResponseDataExcpetion("Unable to parse: " + ex); 
            }
        }
        
    }

    public interface IHttpResponseParser<out TResult>
    {
        TResult ParseAsync(HttpResponseMessage response);
    }
}