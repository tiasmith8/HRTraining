//using FluentNHibernate.Automapping;
//using FluentNHibernate.Automapping.Alterations;
//using HRTraining.Domain.Entities.Workouts;

//namespace HRTraining.Domain.Entities.Profiles
//{
//    public class WorkoutMappingOverride : IAutoMappingOverride<Workout>
//    {
//        public void Override(AutoMapping<Workout> mapping)
//        {
//            mapping.HasMany(m => m.Activities);
//        }
//    }

//    public class WorkoutHistoryMappingOverride : IAutoMappingOverride<WorkoutHistory>
//    {
//        public void Override(AutoMapping<WorkoutHistory> mapping)
//        {
//            mapping.HasMany(m => m.ActivityHistories)
//                .KeyColumn("WorkoutHistoryID");
//        }
//    }
//}
