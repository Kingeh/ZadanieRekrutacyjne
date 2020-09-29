using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MainApp
{
    public class UniversityModel
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public List<string> Web_pages { get; set; }
        public string Alpha_two_code { get; set; }

    }
}
