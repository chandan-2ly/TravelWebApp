using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travel.Core.BusinessModels;
using Travel.Core.Model;
using Travel.IService;

namespace Travel.Controllers
{
    [Route("api/v1/User")]
    [ApiController]
    public class UserController : ControllerBase
    {
        #region variable
        private readonly IUserService _userService;
        #endregion

        #region constructor
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        #endregion

        #region methods
        [HttpGet]
        [Route("TestData")]
        [ProducesResponseType(200)]
        public IActionResult GetTestData()
        {
            return Ok("Hello");
        }

        /// <summary>
        /// Api used for registration of User
        /// </summary>
        /// <param name="registerUser"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("registerUser")]
        [ProducesResponseType(typeof(ListResponseModel), 200)]
        [ProducesErrorResponseType(typeof(ResponseModel))]
        public IActionResult UserRegistration(RegisterUser registerUser)
        {
            if (ModelState.IsValid)
            {
                var result = _userService.RegisterUser(registerUser);
                if (result > 0)
                {
                    return Ok(new ListResponseModel { Message = "Registration Successful" });
                }
            }
            return BadRequest("Something went wrong");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="loginUser"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("authenticateUser")]
        [ProducesResponseType(typeof(ListResponseModel), 200)]
        [ProducesErrorResponseType(typeof(ResponseModel))]
        public async Task<IActionResult> UserAuthentication(AuthenticateRequest loginUser)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.AuthenticateUser(loginUser.Email, loginUser.Password);
                return Ok(result);
            }
            return BadRequest("Something went wrong");
        }
        #endregion
    }
}
