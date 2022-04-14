using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HolidayAvoidance;
using MongoDB.Bson;

namespace Testing
{
    internal class HolidayCustom : IHoliday
    {
        public ObjectId ID { get; set; } = ObjectId.GenerateNewId(); 
        public HolidayAvoidanceAction AvoidanceAction
        {
            get => (HolidayAvoidanceAction)AvoidanceActionID; 
            set
            {
                AvoidanceActionID = (int)value; 
            }
        }
        public DateTimeOffset Date { get; set; }
        public string? Description { get; set; }

        public int AvoidanceActionID { get; set; }
    }
}
