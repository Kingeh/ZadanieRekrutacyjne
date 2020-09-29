using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using college_interview_task_v4;
using MainApp.Models;

namespace MainApp
{
    class ApiHelper
    {
        public static async Task<List<UniversityModel>> AllUniversitiesDataAsync() 
        {
            Client.SetClientUri("http://universities.hipolabs.com");
            var Parser = new Parser<List<UniversityModel>>();
            var universityRequestController = new HttpController<List<UniversityModel>>(Client.ApiClient, Parser);
            var optionalParameters = new Dictionary<string, string>();
            return await universityRequestController.GetEntryAsync("application/json", "Get", "search?" , optionalParameters, new System.Threading.CancellationToken());
        }

        public static async Task<ComicModel> AllComicDataAsync()
        {
            Client.SetClientUri("https://xkcd.com/info.0.json");
            var Parser = new Parser<ComicModel>();
            var comicRequestController = new HttpController<ComicModel>(Client.ApiClient, Parser);
            var optionalParameters = new Dictionary<string, string>();
            return await comicRequestController.GetEntryAsync("application/json", "Get", "", optionalParameters, new System.Threading.CancellationToken());
        }

    }
}
