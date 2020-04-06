using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Travel.Controllers
{
    [Route("api/v1/Test")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        [Route("TestData")]
        [ProducesResponseType(200)]

        public IActionResult GetTestData()
        {
            return Ok("Hello");
        }
    }
}
