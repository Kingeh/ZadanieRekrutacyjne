using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using college_interview_task_v4;
using MainApp.Models;
using Newtonsoft.Json;

namespace MainApp
{
    public class Parser<TRequest> : IHttpResponseParser<TRequest>
    {
        public TRequest ParseAsync(HttpResponseMessage response)
        {
            switch (response.StatusCode)
            {
                case System.Net.HttpStatusCode.OK:
                    Task<string> task = response.Content.ReadAsStringAsync();
                    task.Wait();
                    var text = task.Result;
                    return JsonConvert.DeserializeObject<TRequest>(text);

                case System.Net.HttpStatusCode.InternalServerError:
                    throw new HttpRequestException("Error 500: Generic error has occured on the server.");

                case System.Net.HttpStatusCode.NotFound:
                    throw new HttpRequestException("Error 404: Requested resource does not exist on this server.");

                case System.Net.HttpStatusCode.Conflict:
                    throw new HttpRequestException("Error 409: Conflict on the server.");

                case System.Net.HttpStatusCode.BadRequest:
                    throw new HttpRequestException("Error 400: Request could not be understood by the server.");
                default:
                    throw new HttpRequestException("Unable to parse data.");
            }
        }
    }
}
