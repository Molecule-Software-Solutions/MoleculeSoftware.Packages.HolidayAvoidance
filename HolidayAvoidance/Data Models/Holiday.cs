using Realms; 

namespace HolidayAvoidance
{
    public class Holiday : RealmObject, IHoliday
    {
        [PrimaryKey]
        public string ID { get; set; } = Guid.NewGuid().ToString();
        public DateTime Date { get; set; }
        public string? Description { get; set; }
        public HolidayAvoidanceAction AvoidanceAction { get; set; }
    }
}
