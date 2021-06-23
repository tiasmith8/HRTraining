using HRTraining.Domain.Interfaces;

namespace HRTraining.Domain.Entities
{
    // Holds data for the google maps route image/tracing
    // Incorporate the google api - https://github.com/vivet/GoogleApi
    // Use MapBox instead of google
    public class Route : EntityBase, IRoute
    {
        public virtual string StartPoint { get; set; }
        public virtual string EndPoint { get; set; }

        // List of points in between? - gps tracking points from phone. I don't know.
        // SqlGeography?
        //public virtual Dictionary<double, double> GPSTrackingPoints { get; set; }
        //public virtual SqlGeography GPSTrackingPoints { get; set; }
    }
}
