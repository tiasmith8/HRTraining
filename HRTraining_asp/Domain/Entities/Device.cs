using System;

namespace HRTraining.Domain.Entities
{
    public class Device : EntityBase
    {
        public virtual string Name { get; set; }
        public virtual DeviceManufacturer DeviceManufacturer { get; set; }
        public virtual bool AutoConnect { get; set; }
    }
}
