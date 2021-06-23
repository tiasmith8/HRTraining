using System;

namespace HRTraining_asp.Domain.Entities
{
    public class RouteModel
    {
        public Guid? ID { get; set; }
        public string StartPoint { get; set; }
        public string EndPoint { get; set; }
    }
}
