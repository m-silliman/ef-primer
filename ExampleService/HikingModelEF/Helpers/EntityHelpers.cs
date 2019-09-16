using System.Collections.Generic;

namespace HikingModelEF.Helpers
{
    public static class EntityHelpers
    {
        public static Dto.HikerDto ToDto(this Hiker hiker)
        {
            return ReflectionHelper.Copy<Hiker, Dto.HikerDto>(hiker);
        }
        public static Hiker ToEntity(this Dto.HikerDto hiker)
        {
            return ReflectionHelper.Copy<Dto.HikerDto, Hiker>(hiker);
        }

        public static List<HikingModelEF.Dto.HikerDto> ToDto(this List<HikingModelEF.Hiker> hikeList)
        {
            List<Dto.HikerDto> retList = new List<Dto.HikerDto>();
            hikeList.ForEach(h => retList.Add(h.ToDto()));
            return retList;
        }


        public static Dto.MountainDto ToDto(this Mountain Mountain)
        {
            return ReflectionHelper.Copy<Mountain, Dto.MountainDto>(Mountain);
        }
        public static Mountain ToEntity(this Dto.MountainDto Mountain)
        {
            return ReflectionHelper.Copy<Dto.MountainDto, Mountain>(Mountain);
        }

        public static List<HikingModelEF.Dto.MountainDto> ToDto(this List<HikingModelEF.Mountain> hikeList)
        {
            List<Dto.MountainDto> retList = new List<Dto.MountainDto>();
            hikeList.ForEach(h => retList.Add(h.ToDto()));
            return retList;
        }

        public static Dto.TripDto ToDto(this Trip Trip)
        {
            return ReflectionHelper.Copy<Trip, Dto.TripDto>(Trip);
        }
        public static Trip ToEntity(this Dto.TripDto Trip)
        {
            return ReflectionHelper.Copy<Dto.TripDto, Trip>(Trip);
        }

        public static List<HikingModelEF.Dto.TripDto> ToDto(this List<HikingModelEF.Trip> hikeList)
        {
            List<Dto.TripDto> retList = new List<Dto.TripDto>();
            hikeList.ForEach(h => retList.Add(h.ToDto()));
            return retList;
        }
    }
}
