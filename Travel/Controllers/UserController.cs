﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travel.Core.BusinessModels;
using Travel.Core.Model;
using Travel.IService;
using static Travel.Core.BusinessModels.Constants;

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
                    return Ok(new ListResponseModel { Message = MessageConstants.SignUpSuccessfull });
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
        [ProducesResponseType(typeof(AuthenticateResponse), 200)]
        [ProducesErrorResponseType(typeof(ResponseModel))]
        public async Task<IActionResult> UserAuthentication(AuthenticateRequest loginUser)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.AuthenticateUser(loginUser.Email, loginUser.Password);
                if (result.IsSuccess)
                {
                    Response.Headers.Add("Authorization", result.Token);
                    return Ok(result);
                }
            }
            return BadRequest("Something went wrong");
        }

        [HttpPost]
        [Authorize(Roles = "Customer")]
        [Route("getTest")]
        [ProducesResponseType(typeof(AuthenticateResponse), 200)]
        [ProducesErrorResponseType(typeof(ResponseModel))]
        public string GetTest()
        {
            return "hello";
        }
        #endregion
    }
}
