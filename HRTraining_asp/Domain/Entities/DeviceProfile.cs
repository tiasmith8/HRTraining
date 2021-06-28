using HRTraining.Domain.Entities;

namespace HRTraining_asp.Domain.Entities
{
    public class DeviceProfile : AutoMapper.Profile
    {
        public DeviceProfile()
        {
            CreateMap<Device, DeviceModel>()
                .ReverseMap()
                .ForMember(x => x.ID, x => x.Ignore());
        }
    }
}
