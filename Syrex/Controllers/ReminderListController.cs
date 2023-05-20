using Microsoft.AspNetCore.Mvc;
using Syrex.BusinessLogic.ReminderList;
using Syrex.DTO;
using Syrex.Mappers;

namespace Syrex.Controllers
{
    [Produces("application/json")]
    [Route("reminder-list")]
    public class ReminderListController : Controller
    {
        private readonly IReminderListLogic _reminderListLogic;
        public ReminderListController(IReminderListLogic reminderListLogic)
        {
            _reminderListLogic = reminderListLogic;
        }

        [HttpGet]
        public async Task<IActionResult> GetReminderList()
        {
            return Ok(ReminderListMapper.MapListToDto(await _reminderListLogic.GetReminderList()));
        }

        [HttpGet, Route("{id:Guid}")]
        public async Task<IActionResult> GetReminderListById(Guid id)
        {
            var data = await _reminderListLogic.GetReminderListById(id);
            return Ok(ReminderListMapper.MapToDto(data));
        }

        [HttpPost]
        public async Task<IActionResult> CreateReminderList([FromBody]ReminderListDto reminderListDto)
        {
            var id = await _reminderListLogic.CreateReminderList(ReminderListMapper.MapFromDto(reminderListDto));
            return Ok(id);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateReminderList([FromBody] ReminderListDto reminderListDto)
        {
            await _reminderListLogic.UpdateReminderList(ReminderListMapper.MapFromDto(reminderListDto));
            return Ok();
        }

        [HttpDelete, Route("{id:Guid}")]
        public async Task<IActionResult> DeleteReminderList(Guid id)
        {
            await _reminderListLogic.DeleteReminderList(id);
            return Ok();
        }
    }
}
