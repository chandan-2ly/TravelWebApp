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
    [Route("api/v1/authenticate")]
    [ApiController]
    public class AuthenticateUser : ControllerBase
    {
        private readonly IAuthenticateService _authentication;
        public AuthenticateUser(IAuthenticateService authentication)
        {
            _authentication = authentication;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="loginUser"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("authenticateUser")]
        [ProducesResponseType(typeof(WebApiResponseModel), 200)]
        [ProducesErrorResponseType(typeof(ErrorResponseModel))]
        public IActionResult UserAuthentication(LoginUser loginUser)
        {
            if (ModelState.IsValid)
            {
                var result = _authentication.AuthenticateUser(loginUser.Email, loginUser.Password);
                return Ok(result);
            }
            return BadRequest("Something went wrong");
        }
    }
}
