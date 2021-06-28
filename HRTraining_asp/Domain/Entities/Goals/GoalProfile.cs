using HRTraining.Domain.Entities.Goals;

namespace HRTraining_asp.Domain.Entities.Goals
{
    public class GoalProfile : AutoMapper.Profile
    {
        public GoalProfile()
        {
            CreateMap<Goal, GoalModel>()
                .ReverseMap()
                .ForMember(x => x.ID, x => x.Ignore());
        }
    }
}
