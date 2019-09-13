using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HikingDataModel
{
    public class Challenge
    {
        public Challenge()
        {
            Mountains = new List<Mountain>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public bool HasPatch { get;set;}

        public List<Mountain> Mountains { get; set; }
    }
}
