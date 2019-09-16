using System;

namespace HikingDataModel
{
    public class Trip
    {
        public long Id { get; set; }
        public long HikerId { get; set; }
        public long MountainId { get; set; }
        public DateTime TripDate { get; set; }
        public long Conditions { get; set; }
        public string Report { get; set; }

        public virtual Hiker Hiker { get; set; }
        public virtual Mountain Mountain { get; set; }
    }
}
