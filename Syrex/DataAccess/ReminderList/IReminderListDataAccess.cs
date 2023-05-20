using System.Web.Helpers;
using DataAccessModel = Syrex.DataAccess.Domain;

namespace Syrex.DataAccess.ReminderList
{
    public interface IReminderListDataAccess
    {
        Task<List<DataAccessModel.ReminderList>> GetReminderList();
        Task<DataAccessModel.ReminderList> GetReminderListById(Guid id);
        Task<Guid> CreateReminderList(DataAccessModel.ReminderList reminderDetail);
        Task UpdateReminderList(DataAccessModel.ReminderList reminderDetail);
        Task DeleteReminderList(Guid id);

    }
}
