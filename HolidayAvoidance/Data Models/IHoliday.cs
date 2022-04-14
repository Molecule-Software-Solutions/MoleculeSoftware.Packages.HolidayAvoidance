
using MongoDB.Bson;

namespace HolidayAvoidance
{
    public interface IHoliday
    {
        ObjectId ID { get; set; }
        HolidayAvoidanceAction AvoidanceAction { get; set; }
        DateTimeOffset Date { get; set; }
        string? Description { get; set; }

        public int AvoidanceActionID { get; set; }
    }
}