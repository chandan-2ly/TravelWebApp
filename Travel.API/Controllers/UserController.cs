using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;
using Travel.Core.BusinessModels;
using Travel.Core.Model;
using Travel.IService;

namespace Travel.API.Controllers
{
    [Route("api/v1/[controller]")]
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

        [HttpGet("{id}", Name = "GetUserById")]
        //[Authorize(Roles = "Customer")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> GetUserById(Guid id)
        {
            var result = await _userService.GetUserById(id);
            if(result != null)
            {
                return Ok(new JsonResult(result));
            }
            return NotFound("User not found.");
        }

        [HttpPut("{id}", Name = "UpdateUserById")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> UpdateUserDetails(Guid id, [FromBody] UserDetails user)
        {
            var result = await _userService.UpdateUserDetails(id, user);
            return Ok(result);
        }

        [HttpDelete("{id}", Name = "DeleteUserById")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> DeleteUserById(Guid id)
        {
            var result = await _userService.DeleteUserById(id);
            return Ok(result);
        }

        #endregion
    }
}
