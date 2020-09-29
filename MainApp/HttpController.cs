using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using college_interview_task_v4;
using MainApp.Models;

namespace MainApp
{
    public class HttpController<TRequest> : HttpRequestHandler<TRequest>
    {
        public HttpController(HttpClient httpClientProxy, IHttpResponseParser<TRequest> parser) : base(httpClientProxy, parser)
        {   
        }
    }
}
