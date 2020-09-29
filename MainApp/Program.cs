using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using college_interview_task_v4;

namespace MainApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Client.InitializeClient();

            Console.WriteLine("Please choose from the 3 options: \n1 - University Domains and Names API");
            Console.WriteLine("2 - Current Comic\n0 - Exit the program\n");
            var userOption = Console.ReadLine();

            if (int.TryParse(userOption, out int userOptionInt))
            {
                switch (userOptionInt)
                {
                    case 0:
                        System.Environment.Exit(0);
                        break;
                    case 1:
                        try
                        {
                            var universities = await ApiHelper.AllUniversitiesDataAsync();
                            PrintResults.PrintListOfUniversityResults(universities);

                        }
                        catch (HttpRequestException e)
                        {
                            Console.WriteLine("\nException Caught!");
                            Console.WriteLine("Message :{0} ", e.Message);
                        }
                        break;
                    case 2:
                        try
                        {
                            var comicData = await ApiHelper.AllComicDataAsync();
                            PrintResults.PrintListOfComicResults(comicData);
                        }
                        catch (HttpRequestException e)
                        {
                            Console.WriteLine("\nException Caught!");
                            Console.WriteLine("Message :{0} ", e.Message);
                        }
                        break;
                    default:
                        InvalidOption();
                        break;
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            else
            {
                InvalidOption();
            }

        }

        static void InvalidOption()
        {
            Console.WriteLine("\nInvalid option.\n");
            Thread.Sleep(1500);
        }
    }
}
