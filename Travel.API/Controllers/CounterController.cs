using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Travel.Core.BusinessModels;
using Travel.Core.Model;
using Travel.IService;

namespace Travel.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CounterController : ControllerBase
    {
        private readonly ICounterService _counterService;

        public CounterController(ICounterService counterService)
        {
            _counterService = counterService ?? throw new ArgumentNullException(nameof(counterService));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IActionResult), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetCounters()
        {
            var result = await _counterService.GetCounters();
            if(result.Count > 0)
            {
                return Ok(new ListResponseModel { Items = result, Message = MessageConstants.RetrievalSuccess, TotalRecords = result.Count });
            }
            return BadRequest(MessageConstants.SomethingWentWrong);
        }

        [HttpPost]
        //[ProducesResponseType(typeof(IActionResult), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> AddCounter(CounterDetails counter)
        {
            var result = await _counterService.AddCounter(counter);
            if (result)
            {
                return Ok(true);
            }
            return BadRequest(MessageConstants.SomethingWentWrong);
        }
    }
}
