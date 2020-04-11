using System;
using System.Collections.Generic;
using System.Text;

namespace Travel.Core.Model
{
    public class WebApiResponse
    {
        public List<dynamic> Items { get; set; }
        public string Message { get; set; }
        public dynamic TotalRecords { get; set; }
    }
}
