//using FluentNHibernate.Automapping;
//using FluentNHibernate.Automapping.Alterations;
//using HRTraining.Domain.Entities;
//using HRTraining.Domain.Entities.Profiles;

//namespace HRTraining_asp.Domain.Entities.Maps
//{
//    public class ProfileMappingOverride : IAutoMappingOverride<Profile>
//    {
//        public void Override(AutoMapping<Profile> mapping)
//        {
//            mapping.HasMany(p => p.Devices)
//                .Cascade.AllDeleteOrphan()
//                .Not.LazyLoad();
//        }
//    }
//}
