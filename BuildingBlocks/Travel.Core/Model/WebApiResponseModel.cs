using System.Collections.Generic;

namespace Travel.Core.Model
{
    public class WebApiResponseModel
    {
        public List<dynamic> Items { get; set; }
        public string Message { get; set; }
        public dynamic TotalRecords { get; set; }
    }
}
