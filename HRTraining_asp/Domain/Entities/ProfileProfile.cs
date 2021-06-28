using AutoMapper;

namespace HRTraining_asp.Domain.Entities
{
    public class ProfileProfile : Profile
    {
        public ProfileProfile()
        {
            CreateMap<HRTraining.Domain.Entities.Profile, ProfileModel>()
                .ReverseMap()
                .ForMember(x => x.ID, x => x.Ignore());
        }
    }
}
