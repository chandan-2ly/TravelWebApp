using Microsoft.AspNetCore.Mvc;
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

        [HttpPost]
        //[Authorize(Roles = "Customer")]
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
