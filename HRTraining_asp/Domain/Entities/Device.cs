using System;

namespace HRTraining.Domain.Entities
{
    public class Device
    {
        public virtual Guid Id { get; set; } // This could come from the device itself?
        public virtual string Name { get; set; }
        public virtual DeviceManufacturer DeviceManufacturer { get; set; }
        public virtual bool AutoConnect { get; set; }
    }
}
