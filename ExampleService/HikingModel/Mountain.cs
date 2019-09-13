using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HikingDataModel
{
    public class Mountain
    {
        public Mountain()
        {
            Challenges = new List<Challenge>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long Elevation { get; set; }
        public float Distance { get; set; }
        public long ElevationGain { get; set; }

        public List<Challenge> Challenges { get; set; }
    }
}
