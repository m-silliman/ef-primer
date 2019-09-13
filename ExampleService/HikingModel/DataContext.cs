using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HikingDataModel
{
    public class DataContext
    {
        public DataContext()
        {
            CreateDataModel();
        }

        private void CreateDataModel()
        {
            Hikers = new List<Hiker>();
            Hikers.Add(new Hiker() { Id = 1, AdkMember = true, DateOfBirth = new DateTime(1980, 10, 2), Experience = 10, Name = "Rose", TrailName = "Sasquatch" });
            Hikers.Add(new Hiker() { Id = 2, AdkMember = true, DateOfBirth = new DateTime(1985, 10, 2), Experience = 8, Name = "Decker", TrailName = "BearBait" });
            Hikers.Add(new Hiker() { Id = 3, AdkMember = true, DateOfBirth = new DateTime(1982, 10, 2), Experience = 5, Name = "Silliman", TrailName = "Silly" });
            Hikers.Add(new Hiker() { Id = 4, AdkMember = true, DateOfBirth = new DateTime(1983, 10, 2), Experience = 4, Name = "Fitzsimmons", TrailName = "FitzMule" });
            Hikers.Add(new Hiker() { Id = 5, AdkMember = true, DateOfBirth = new DateTime(1983, 10, 2), Experience = 4, Name = "Huynh", TrailName = "X" });
            Hikers.Add(new Hiker() { Id = 5, AdkMember = true, DateOfBirth = new DateTime(1983, 10, 2), Experience = 1, Name = "Dann", TrailName = "LostDog" });

            Mountains = new List<Mountain>();
            Mountains.Add(new Mountain() { Id = 1, Name = "Snowy Mountain", Elevation = 3904, Distance = 3.8f, ElevationGain = 2100 });
            Mountains.Add(new Mountain() { Id = 2, Name = "Lyon Mountain", Elevation = 3830, Distance = 3.4f, ElevationGain = 1900 });
            Mountains.Add(new Mountain() { Id = 3, Name = "Blue Mountain", Elevation = 3759, Distance = 2.5f, ElevationGain = 1560 });
            Mountains.Add(new Mountain() { Id = 4, Name = "Wakely Mountain", Elevation = 3744, Distance = 3.2f, ElevationGain = 1636 });
            Mountains.Add(new Mountain() { Id = 5, Name = "Hurricane Mountain", Elevation = 3694, Distance = 2.6f, ElevationGain = 2000 });
            Mountains.Add(new Mountain() { Id = 6, Name = "Pillsbury Mountain", Elevation = 3597, Distance = 1.6f, ElevationGain = 1300 });
            Mountains.Add(new Mountain() { Id = 7, Name = "Gore Mountain", Elevation = 3583, Distance = 5.0f, ElevationGain = 2590 });
            Mountains.Add(new Mountain() { Id = 8, Name = "Mount Adams 3520", Elevation = 3830, Distance = 2.5f, ElevationGain = 1700 });
            Mountains.Add(new Mountain() { Id = 9, Name = "Vanderwhacker Mountain", Elevation = 3830, Distance = 2.9f, ElevationGain = 1700 });
            Mountains.Add(new Mountain() { Id = 10, Name = "Loon Lake Mountain", Elevation = 3830, Distance = 2.8f, ElevationGain = 1642 });


            Challenges = new List<Challenge>();
            Challenges.Add(new Challenge() {  Id = 1, Name = "Fire Tower", HasPatch = true });
            Challenges.Last().Mountains = this.Mountains.Take(10).ToList();

            Challenges.Add(new Challenge() { Id = 1, Name = "Herkimer County Towers", HasPatch = true });
            Challenges.Last().Mountains = this.Mountains.Take(5).ToList();

        }

        public ICollection<Hiker> Hikers { get;set; }
        public ICollection<Mountain> Mountains { get; set; }
        public ICollection<Challenge> Challenges { get; set; }
    }
}
