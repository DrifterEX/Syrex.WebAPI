using Syrex.BusinessLogic.ReminderList;
using Syrex.DataAccess.ReminderList;

namespace Syrex
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddBusinessLogic(this IServiceCollection services)
        {
            /// Ideally this should be AddScoped or depends on how you want the service to behave. For now I'm using singleton
            /// since we store data to web cache
            services.AddSingleton<IReminderListLogic, ReminderListLogic>();
            return services;
        }

        public static IServiceCollection AddDataAccess(this IServiceCollection services)
        {
            /// Ideally this should be AddScoped or depends on how you want the service to behave. For now I'm using singleton
            /// since we store data to web cache
            services.AddSingleton<IReminderListDataAccess, ReminderListDataAccess>();
            return services;
        }
    }
}
