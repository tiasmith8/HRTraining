using HRTraining.Domain.Entities.Workouts;

namespace HRTraining_asp.Domain.Entities.Workouts
{
    public class WorkoutHistoryProfile : AutoMapper.Profile
    {
        public WorkoutHistoryProfile()
        {
            CreateMap<WorkoutHistory, WorkoutHistoryModel>()
                .ReverseMap()
                .ForMember(x => x.ID, x => x.Ignore());
        }
    }
}
