﻿using MongoDB.Bson;
using Realms; 

namespace HolidayAvoidance
{
    public class Holiday : RealmObject, IHoliday
    {
        [PrimaryKey]
        public ObjectId ID { get; set; } = ObjectId.GenerateNewId(); 
        public DateTimeOffset Date { get; set; }
        public string? Description { get; set; }
        public HolidayAvoidanceAction AvoidanceAction
        {
            get => (HolidayAvoidanceAction)AvoidanceActionID; 
            set
            {
                AvoidanceActionID = (int)value; 
            }
        }

        public int AvoidanceActionID { get; set; }
    }
}
