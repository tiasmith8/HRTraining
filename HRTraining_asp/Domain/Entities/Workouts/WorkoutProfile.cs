using HRTraining.Domain.Entities;

namespace HRTraining_asp.Domain.Entities.Workouts
{
    public class WorkoutProfile : AutoMapper.Profile
    {
        public WorkoutProfile()
        {
            CreateMap<Workout, WorkoutModel>()
                .ReverseMap()
                .ForMember(x => x.ID, x => x.Ignore());
        }
    }
}
