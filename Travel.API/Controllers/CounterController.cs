using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;
using Travel.API.Filters;
using Travel.Core.BusinessModels;
using Travel.Core.Model;
using Travel.IService;

namespace Travel.API.Controllers
{
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    [Authorize("SuperAdmin", "Counter")]
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
            if (result != null)
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

        // GET api/<CounterController>/5
        [HttpGet]
        [ProducesResponseType(typeof(IActionResult), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetCounter(int id)
        {
            var result = await _counterService.GetCounterById(id);
            if (result != null)
            {
                return Ok(new ListResponseModel { Items = result, Message = MessageConstants.RetrievalSuccess });
            }
            return BadRequest(MessageConstants.SomethingWentWrong);
        }

        // PUT api/<CounterController>/5
        [HttpPut]
        [ProducesResponseType(typeof(IActionResult), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateCounter(int id, [FromBody] CounterDetails counter)
        {
            var result = await _counterService.UpdateCounter(id, counter);
            return Ok(result);
        }

        // DELETE api/<CounterController>/5
        [HttpDelete]
        [ProducesResponseType(typeof(IActionResult), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteCounter(int id)
        {
            var result = await _counterService.DeleteCounter(id);
            return Ok(result);
        }

        // DELETE api/<CounterController>/5
        [HttpDelete]
        [ProducesResponseType(typeof(IActionResult), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> HardDeleteCounter(int id)
        {
            var result = await _counterService.HardDeleteCounter(id);
            return Ok(result);
        }
    }
}
