using HRTraining.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRTraining_asp.Domain.Entities
{
    public class RouteProfile : AutoMapper.Profile
    {
        public RouteProfile()
        {
            CreateMap<Route, RouteModel>()
                .ReverseMap()
                .ForMember(x => x.ID, x => x.Ignore());
        }
    }
}
