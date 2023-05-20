using Syrex.BusinessLogic.Model;

namespace Syrex.BusinessLogic.ReminderList
{
    public interface IReminderListLogic
    {
        Task<List<ReminderListModel>> GetReminderList();
        Task<ReminderListModel> GetReminderListById(Guid id);
        Task<Guid> CreateReminderList(ReminderListModel reminderDetail);
        Task UpdateReminderList(ReminderListModel reminderDetail);
        Task DeleteReminderList(Guid id);
    }
}
