using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HikingDataModel
{
    public class HikerDbEntities
    {
        public HikerDbEntities()
        {
            CreateDataModel();
        }

        private void CreateDataModel()
        {
            Hiker = new List<Hiker>();

            Hiker.Add(new Hiker() { Id = 1, DateOfBirth = new DateTime(1980, 10, 2), Experience = 10, Name = "Rose", TrailName = "Sasquatch" });
            Hiker.Add(new Hiker() { Id = 2, DateOfBirth = new DateTime(1985, 10, 2), Experience = 8, Name = "Decker", TrailName = "BearBait" });
            Hiker.Add(new Hiker() { Id = 3, DateOfBirth = new DateTime(1982, 10, 2), Experience = 5, Name = "Silliman", TrailName = "Silly" });
            Hiker.Add(new Hiker() { Id = 4, DateOfBirth = new DateTime(1983, 10, 2), Experience = 4, Name = "Fitzsimmons", TrailName = "FitzMule" });
            Hiker.Add(new Hiker() { Id = 5, DateOfBirth = new DateTime(1983, 10, 2), Experience = 4, Name = "Huynh", TrailName = "X" });
            Hiker.Add(new Hiker() { Id = 5, DateOfBirth = new DateTime(1983, 10, 2), Experience = 1, Name = "Dann", TrailName = "LostDog" });

            Mountain = new List<Mountain>();
            Mountain.Add(new Mountain() { Id = 1, Name = "Snowy Mountain", Elevation = 3904, Distance = 3.8f, ElevationGain = 2100 });
            Mountain.Add(new Mountain() { Id = 2, Name = "Lyon Mountain", Elevation = 3830, Distance = 3.4f, ElevationGain = 1900 });
            Mountain.Add(new Mountain() { Id = 3, Name = "Blue Mountain", Elevation = 3759, Distance = 2.5f, ElevationGain = 1560 });
            Mountain.Add(new Mountain() { Id = 4, Name = "Wakely Mountain", Elevation = 3744, Distance = 3.2f, ElevationGain = 1636 });
            Mountain.Add(new Mountain() { Id = 5, Name = "Hurricane Mountain", Elevation = 3694, Distance = 2.6f, ElevationGain = 2000 });
            Mountain.Add(new Mountain() { Id = 6, Name = "Pillsbury Mountain", Elevation = 3597, Distance = 1.6f, ElevationGain = 1300 });
            Mountain.Add(new Mountain() { Id = 7, Name = "Gore Mountain", Elevation = 3583, Distance = 5.0f, ElevationGain = 2590 });
            Mountain.Add(new Mountain() { Id = 8, Name = "Mount Adams 3520", Elevation = 3830, Distance = 2.5f, ElevationGain = 1700 });
            Mountain.Add(new Mountain() { Id = 9, Name = "Vanderwhacker Mountain", Elevation = 3830, Distance = 2.9f, ElevationGain = 1700 });
            Mountain.Add(new Mountain() { Id = 10, Name = "Loon Lake Mountain", Elevation = 3830, Distance = 2.8f, ElevationGain = 1642 });


            Challenge = new List<Challenge>();
            Challenge.Add(new Challenge() {  Id = 1, Name = "Fire Tower", HasPatch = true });
            Challenge.Last().Mountains = this.Mountain.Take(10).ToList();

            Challenge.Add(new Challenge() { Id = 1, Name = "Herkimer County Towers", HasPatch = true });
            Challenge.Last().Mountains = this.Mountain.Take(5).ToList();

        }

        public ICollection<Hiker> Hiker { get;set; }
        public ICollection<Mountain> Mountain { get; set; }
        public ICollection<Challenge> Challenge { get; set; }
        public ICollection<Trip> Trip { get; set; }
    }
}
