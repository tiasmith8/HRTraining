using HRTraining.Domain.Entities;

namespace HRTraining_asp.Domain.Entities
{
    public class AccountProfile : AutoMapper.Profile
    {
        public AccountProfile()
        {
            CreateMap<Account, AccountProfile>()
                .ReverseMap()
                .ForMember(x => x.ID, x => x.Ignore());
        }
    }
}
