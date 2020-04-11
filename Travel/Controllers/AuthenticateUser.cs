using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travel.BusinessModels;
using Travel.Core.Model;
using Travel.IService;

namespace Travel.Controllers
{
    public class AuthenticateUser : ControllerBase
    {
        private readonly IAuthentication _authentication;
        public AuthenticateUser(IAuthentication authentication)
        {
            _authentication = authentication;
        }
        //[HttpPost]
        //[ProducesResponseType(typeof(WebApiResponse), 200)]
        //public async Task<IActionResult> UserAuthentication(LoginUser loginUser)
        //{
        //    var result = new WebApiResponse();

        //    if (ModelState.IsValid)
        //    {
        //        var result = await _authentication.AuthenticateUser(loginUser.Email, loginUser.Password);
        //    }
        //}
    }
}
