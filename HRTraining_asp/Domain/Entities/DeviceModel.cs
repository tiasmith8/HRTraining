using HRTraining;
using System;

namespace HRTraining_asp.Domain.Entities
{
    public class DeviceModel
    {
        public Guid? ID { get; set; }
        public string Name { get; set; }
        public DeviceManufacturer DeviceManufacturer { get; set; }
        public bool AutoConnect { get; set; }
    }
}
