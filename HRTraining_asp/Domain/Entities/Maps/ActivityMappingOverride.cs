//using FluentNHibernate.Automapping;
//using FluentNHibernate.Automapping.Alterations;
//using HRTraining.Domain.Entities.Activities;

//namespace HRTraining_asp.Domain.Entities.Maps
//{
//    public class ActivityMappingOverride : IAutoMappingOverride<Activity>
//    {
//        public void Override(AutoMapping<Activity> mapping)
//        {
//            mapping.HasMany(m => m.Targets)
//                .ForeignKeyConstraintName("FK_Activity_Activity_CooldownId")
//                .Cascade.AllDeleteOrphan()
//                .Not.LazyLoad();

//            mapping.DiscriminateSubClassesOnColumn("Discriminator");

//        }
//    }
//}
