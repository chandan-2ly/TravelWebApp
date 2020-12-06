using System;
using System.Collections.Generic;
using System.Text;
using Travel.Core.Model;

namespace Travel.Core.BusinessModels
{
    public class AuthenticateResponse : ResponseModel
    {
        public IEnumerable<dynamic> ErrorList { get; set; }
        public string Email { get; set; }
        public int Role { get; set; }
    }
}
