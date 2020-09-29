using System;
using System.Collections.Generic;
using System.Text;
using college_interview_task_v4;
using MainApp.Models;

namespace MainApp
{
    class PrintResults
    {
        public static void PrintListOfUniversityResults(List<UniversityModel> universities)
        {
            Console.WriteLine("Results:");
            foreach (var field in universities)
                Console.WriteLine($"Webpage: {field.Web_pages[0]}, Country: {field.Country}, Name: {field.Name}");
        }
        public static void PrintListOfComicResults(ComicModel comics)
        {
            Console.WriteLine("Results:");
            Console.WriteLine($"Num: {comics.num}, Link: {comics.link}, Year: {comics.year}, Transcript: {comics.transcript}, title: {comics.title}");
        }
    }
}
