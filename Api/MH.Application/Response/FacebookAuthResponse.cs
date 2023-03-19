using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MH.Application.Response
{
    public class FacebookAuthResponse
    {
        public Error error { get; set; }
    }
    public class Error
    {
        public string message { get; set; }
        public string type { get; set; }
        public int code { get; set; }
        public string fbtrace_id { get; set; }
    }
}

