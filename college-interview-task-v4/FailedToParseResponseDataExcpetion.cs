using System;
using System.Collections.Generic;
using System.Text;

namespace MainApp
{
    public class FailedToParseResponseDataExcpetion : Exception
    {
        public FailedToParseResponseDataExcpetion()
        {

        }

        public FailedToParseResponseDataExcpetion(string data) : base(String.Format("Failed To Parse Response Data: {0}", data))
        {

        }
    }
}
