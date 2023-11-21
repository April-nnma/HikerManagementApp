
using SQLite;
using System;
namespace HikerManagementApp
{
    [Table("Hike")]


    public class Hike
    {
        public int HikeId { get; set; }
        public string HikeName { get; set; }
        public string HikeLocation { get; set; }
        public DateTime HikeDate { get; set; }
        public TimeSpan HikeTime { get; set; }
        public int HikeDays { get; set; }
        public string HikeLength { get; set; }
        public bool HikeParking { get; set; }
        public string HikeLevel { get; set; }
        public string HikeDescription { get; set; }
        public string HikeGear { get; set; }
        public Hike() { }

        public Hike(int hikeId, string hikeName, string hikeLocation, DateTime hikeDate, TimeSpan hikeTime, int hikeDays, string hikeLength,
                 bool hikeParking, string hikeLevel, string hikeDescription, string hikeGear)
        {
            HikeId = hikeId;
            HikeName = hikeName;
            HikeLocation = hikeLocation;
            HikeDate = hikeDate;
            HikeTime = hikeTime;
            HikeDays = hikeDays;
            HikeLength = hikeLength;
            HikeParking = hikeParking;
            HikeLevel = hikeLevel;
            HikeDescription = hikeDescription;
            HikeGear = hikeGear;
        }
    }
}
