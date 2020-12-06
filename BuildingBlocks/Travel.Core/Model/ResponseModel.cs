using System;

namespace Travel.Core.Model
{
    public class ResponseModel
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public Guid UserId { get; set; }
    }
}
