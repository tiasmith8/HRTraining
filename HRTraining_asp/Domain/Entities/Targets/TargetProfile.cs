using HRTraining.Domain.Entities.Targets;
using HRTraining_asp.Domain.Entities.Targets.Models;

namespace HRTraining_asp.Domain.Entities.Targets
{
    public class TargetProfile : AutoMapper.Profile
    {
        public TargetProfile()
        {
            CreateMap<Target, TargetModel>()
                .ReverseMap()
                .ForMember(x => x.ID, x => x.Ignore());
        }
    }
}
