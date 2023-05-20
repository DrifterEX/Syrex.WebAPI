using System.Web.Helpers;
using DataAccessModel = Syrex.DataAccess.Domain;

namespace Syrex.DataAccess.ReminderList
{
    public class ReminderListDataAccess: IReminderListDataAccess
    {
        private readonly string _reminderListKey = "ReminderListKey";
        private List<DataAccessModel.ReminderList> InitialReminderList = new List<Domain.ReminderList>();

        public ReminderListDataAccess()
        {
            InitializeTemporaryStorage();
        }

        public async Task<List<DataAccessModel.ReminderList>> GetReminderList()
        {
            /// For this demo, Data are temporarily stored on webcache
            /// But in real world scenario, data are stored on database and are fetched via Entity Framework
            /// or ADO.NET, Dapper, etc.
            var reminderList = (List<DataAccessModel.ReminderList>)WebCache.Get(_reminderListKey);
            await Task.CompletedTask;
            return reminderList;
        }

        public async Task<DataAccessModel.ReminderList> GetReminderListById(Guid id)
        {
            /// For this demo, Data are temporarily stored on webcache
            /// This should be an entity framework query to the database to fetch the reminder list by id
            /// but for now we have to get first the list from WebCache then return the reminder detail record
            var reminderList = (List<DataAccessModel.ReminderList>)WebCache.Get(_reminderListKey);
            await Task.CompletedTask;

            // This is using First() only because we expected to return only one record.
            // Should throw an error if we get multiple result
            return reminderList.First(x => x.Id == id);
        }

        public async Task<Guid> CreateReminderList(DataAccessModel.ReminderList reminderDetail)
        {
            try
            {
                /// For this demo, Data are temporarily stored on webcache
                /// This should be an entity framework query to the database to create the reminder list
                /// but for now we are storing it to web cache
                var reminderList = (List<DataAccessModel.ReminderList>)WebCache.Get(_reminderListKey);
                if (reminderList == null)
                {
                    reminderList = new List<DataAccessModel.ReminderList>();
                }
                var Id = Guid.NewGuid();
                reminderList.Add(new DataAccessModel.ReminderList()
                {
                    Id = Id,
                    Name = reminderDetail.Name,
                    Description = reminderDetail.Description,
                    ReminderDate = reminderDetail.ReminderDate,
                    Status = reminderDetail.Status,
                });

                WebCache.Set(_reminderListKey, reminderList);

                await Task.CompletedTask;
                return Id;
            }
            catch (Exception)
            {
                /// In here we can do logging if we have system logger in place. But for now we return empty Guid
                /// in case of an exception error
                return Guid.Empty;
            }
        }

        public async Task UpdateReminderList(DataAccessModel.ReminderList reminderDetail)
        {
            try
            {
                /// For this demo, Data are temporarily stored on webcache
                /// This should be an entity framework query to the database to edit the reminder list
                /// but for now we are storing it to web cache
                var reminderList = (List<DataAccessModel.ReminderList>)WebCache.Get(_reminderListKey);
                var recordToUpdate = reminderList.Where(o => o.Id  == reminderDetail.Id).FirstOrDefault();
                if (recordToUpdate != null)
                {
                    recordToUpdate.Name = reminderDetail.Name;
                    recordToUpdate.Description = reminderDetail.Description;
                    recordToUpdate.ReminderDate = reminderDetail.ReminderDate;
                    recordToUpdate.Status = reminderDetail.Status;
                }

                WebCache.Set(_reminderListKey, reminderList);

                await Task.CompletedTask;
            }
            catch (Exception)
            {
                /// In here we can do logging if we have system logger in place.              
            }
        }

        public async Task DeleteReminderList(Guid id)
        {
            try
            {
                /// For this demo, Data are temporarily stored on webcache
                /// This should be an entity framework query to the database to delete the reminder list
                /// but for now we are storing it to web cache
                var reminderList = (List<DataAccessModel.ReminderList>)WebCache.Get(_reminderListKey);

                WebCache.Set(_reminderListKey, reminderList.Where(o => o.Id != id).ToList());

                await Task.CompletedTask;
            }
            catch (Exception)
            {
                /// In here we can do logging if we have system logger in place.              
            }
        }

        private void InitializeTemporaryStorage()
        {
            WebCache.Set(_reminderListKey, InitialReminderList);
        }
    }
}
