using CalendarAPI.Models;
using CalendarAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CalendarAPI.Controllers
{
    [ApiController]
    [Route("CalendarDate")]
    public class CalendarDateController : ControllerBase
    {
        private readonly IUserDateTimeService _userDateTimeService;

        public CalendarDateController(IUserDateTimeService userDateTimeService)
        {
            _userDateTimeService = userDateTimeService;
        }

        [HttpGet("{id}")]
        public async Task<IEnumerable<UserDateTime>> GetGetUserDateTimesById(int id)
        {
            return await _userDateTimeService.GetUserDateTimesByIdAsync(id);
        }

        [HttpGet("{id}/{day}")]
        public async Task<IEnumerable<UserDateTime>> GetUserDateTimeByIdAndDayAsync(int id, DateTime day)
        {
            return await _userDateTimeService.GetUserDateTimeByIdAndDayAsync(id, day);
        }

        [HttpPost]
        public async Task<ActionResult> Insert(UserDateTime userDateTime)
        {
            await _userDateTimeService.InsertAsync(userDateTime);
            return Ok();
        }

        [HttpPut]
        public async Task<bool> Update(UserDateTime userDateTime)
        {
            return await _userDateTimeService.UpdateAsync(userDateTime);
        }

        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            return await _userDateTimeService.DeleteAsync(id);
        }
    }
}
