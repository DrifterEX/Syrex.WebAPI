using AutoMapper;
using Syrex.BusinessLogic.Model;
using Syrex.DataAccess.ReminderList;
using Syrex.Mappers;

namespace Syrex.BusinessLogic.ReminderList
{
    public class ReminderListLogic: IReminderListLogic
    {
        private readonly IReminderListDataAccess _reminderListDataAccess;
        public ReminderListLogic(IReminderListDataAccess reminderListDataAccess)
        {
            _reminderListDataAccess = reminderListDataAccess;
        }

        public async Task<List<ReminderListModel>> GetReminderList()
        {
            var data = await _reminderListDataAccess.GetReminderList();
            return ReminderListMapper.MapList(data);
        }

        public async Task<ReminderListModel> GetReminderListById(Guid id)
        {
            var data = await _reminderListDataAccess.GetReminderListById(id);
            return ReminderListMapper.Map(data);
        }

        public async Task<Guid> CreateReminderList(ReminderListModel reminderDetail)
        {
            return await _reminderListDataAccess.CreateReminderList(ReminderListMapper.Map(reminderDetail));
        }

        public async Task UpdateReminderList(ReminderListModel reminderDetail)
        {
            await _reminderListDataAccess.UpdateReminderList(ReminderListMapper.Map(reminderDetail));
        }

        public async Task DeleteReminderList(Guid id)
        {
            await _reminderListDataAccess.DeleteReminderList(id);
        }
    }
}
