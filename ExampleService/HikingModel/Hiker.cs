using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HikingDataModel
{
    public class Hiker
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string TrailName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Experience { get; set; }
    }
}
