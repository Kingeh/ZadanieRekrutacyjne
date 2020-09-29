using System;
using System.Net.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace college_interview_task_v4.UnitTests
{
    [TestClass]
    public class HttpRequestHandlerTests
    {
        [TestMethod]
        [ExpectedException(typeof(HttpRequestException))]
        public void GetEntryAsync_Payload_IsNull()
        {
            HttpClient ApiClient = new HttpClient();
            ApiClient.BaseAddress = new Uri("https://xkcd.com/info.0.json");
            var Parser = new Parser<ComicModel>();
            var comicRequestController = new HttpController<ComicModel>(Client.ApiClient, Parser);
            var optionalParameters = new Dictionary<string, string>();
            return await comicRequestController.GetEntryAsync("application/json", "Get", "", optionalParameters, new System.Threading.CancellationToken());
        }

        [TestMethod]
        public void GetEntryAsync_HeadersAreNull_Exception()
        {

        }

        [TestMethod]
        public void GetEntryAsync_BadResponse_Exception()
        {

        }
        [TestMethod]
        public void GetEntryAsync_UnableToParse_Exception()
        {

        }

        [TestMethod]
        public void GetEntryAsync_SuccessfulParse_Excpetion()
        {

        }
    }
}
