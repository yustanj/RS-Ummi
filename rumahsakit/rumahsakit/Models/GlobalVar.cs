using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace rumahsakit.Models
{
    public static class GlobalVar
    {
        public static RestClient Domain => new RestClient("https://apisentris.com/api/v1/");
    }
}
