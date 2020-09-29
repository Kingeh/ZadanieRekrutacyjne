using NUnit.Framework;
using NUnit.Compatibility;
using college_interview_task_v4;
using MainApp;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.IO;
using MainApp.Models;

namespace HttpRequestHandler.UnitTests
{
    public class Tests
    {
        public Parser<List<UniversityModel>> parser;
        public HttpController<List<UniversityModel>> universityRequestController;
        Dictionary<string, string> optionalParameters;

        [SetUp]
        public void Setup()
        {
            Client.InitializeClient();
            Client.SetClientUri("http://universities.hipolabs.com");
            parser = new Parser<List<UniversityModel>>();
            universityRequestController = new HttpController<List<UniversityModel>>(Client.ApiClient, parser);
            optionalParameters = new Dictionary<string, string>();
           
        }

        [Test]
        public void GetEntryAsync_PayloadIsNull_Exception()
        {
            Task<List<UniversityModel>> result = universityRequestController.GetEntryAsync(null, "Get", "search?", optionalParameters, new System.Threading.CancellationToken());

             Assert.That(() => result, Throws.TypeOf<HttpRequestException>());

        }

        [Test]
        public void TestGetEntryAsync_HeadersAreNull_Exception()
        {
            Task<List<UniversityModel>> result = universityRequestController.GetEntryAsync("application/json", "Get", "search?", null, new System.Threading.CancellationToken());

            Assert.That(() => result, Throws.TypeOf<HttpRequestException>());
        }

        [Test]
        public void GetEntryAsync_ResponseIsBad_Exception()
        {
            Task<List<UniversityModel>> result = universityRequestController.GetEntryAsync("application/json", "Get", "wrongEndPoint", optionalParameters, new System.Threading.CancellationToken());

            Assert.That(() => result, Throws.TypeOf<EndOfStreamException>());
        }

        [Test]
        public void GetEntryAsync_ParseIsBad_Exception()
        {
            var parser = new Parser<ComicModel>();
            var comicsRequestController = new HttpController<ComicModel>(Client.ApiClient, parser);

            Task <ComicModel> result = comicsRequestController.GetEntryAsync("application/json", "Get", "search?name=middle", optionalParameters, new System.Threading.CancellationToken());

            Assert.That(() => result, Throws.TypeOf<FailedToParseResponseDataExcpetion>());
        }

        [Test]
        public void GetEntryAsync_ParseIsGood_TRequest()
        {
            Task<List<UniversityModel>> taskResult = universityRequestController.GetEntryAsync("application/json", "Get", "search?", optionalParameters, new System.Threading.CancellationToken());
            taskResult.Wait();
            List<UniversityModel> result = taskResult.Result;

            Assert.IsNotNull(result);
        }
    }
}