using HRTraining.Domain.Entities;
using HRTraining.Domain.Entities.Activities;
using HRTraining_asp.Domain.Entities.Activities.Models;

namespace HRTraining_asp.Domain.Entities.Activities
{
    public class ActivityProfile : AutoMapper.Profile
    {
        public ActivityProfile()
        {
            CreateMap<Activity, ActivityModel>()
                .ReverseMap()
                .ForMember(x => x.ID, x => x.Ignore());

            CreateMap<ActivityHistory, ActivityHistoryModel>()
                .ReverseMap()
                .ForMember(x => x.ID, x => x.Ignore());

            CreateMap<ActivityStatistics, ActivityStatisticsModel>()
                .ReverseMap()
                .ForMember(x => x.ID, x => x.Ignore());
        }
    }
}
