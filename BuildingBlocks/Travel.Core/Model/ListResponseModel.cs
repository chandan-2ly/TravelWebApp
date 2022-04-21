using System.Collections.Generic;

namespace Travel.Core.Model
{
    public class ListResponseModel
    {
        public dynamic Items { get; set; }
        public string Message { get; set; }
        public dynamic TotalRecords { get; set; }
    }
}
