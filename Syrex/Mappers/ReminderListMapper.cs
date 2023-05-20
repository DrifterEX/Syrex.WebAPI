using AutoMapper;
using Syrex.BusinessLogic.Model;
using Syrex.DataAccess.Domain;
using Syrex.DTO;

namespace Syrex.Mappers
{
    public class ReminderListMapper
    {
        private static readonly IMapper _mapper;

        static ReminderListMapper()
        {
            var config = new MapperConfiguration(cft =>
            {
                cft.CreateMap<ReminderList, ReminderListModel>()
                    .ReverseMap();

                cft.CreateMap<ReminderListModel, ReminderListDto>()
                    .ReverseMap();
            });

            _mapper = config.CreateMapper();
        }

        public static ReminderListModel Map(ReminderList reminderList)
        {
            return _mapper.Map<ReminderListModel>(reminderList);
        }

        public static ReminderList Map(ReminderListModel reminderList)
        {
            return _mapper.Map<ReminderList>(reminderList);
        }

        public static ReminderListModel MapFromDto(ReminderListDto reminderList)
        {
            return _mapper.Map<ReminderListModel>(reminderList);
        }

        public static ReminderListDto MapToDto(ReminderListModel reminderListModel)
        {
            return _mapper.Map<ReminderListDto>(reminderListModel);
        }

        public static List<ReminderList> MapList(List<ReminderListModel> reminderListModel)
        {
            return _mapper.Map<List<ReminderList>>(reminderListModel);
        }

        public static List<ReminderListModel> MapList(List<ReminderList> reminderList)
        {
            return _mapper.Map<List<ReminderListModel>>(reminderList);
        }

        public static List<ReminderListDto> MapListToDto(List<ReminderListModel> reminderListModel)
        {
            return _mapper.Map<List<ReminderListDto>>(reminderListModel);
        }
    }

        
}
