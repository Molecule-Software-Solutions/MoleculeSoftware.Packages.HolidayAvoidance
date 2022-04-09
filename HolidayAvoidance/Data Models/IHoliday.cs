
namespace HolidayAvoidance
{
    public interface IHoliday
    {
        string ID { get; set; }
        HolidayAvoidanceAction AvoidanceAction { get; set; }
        DateTime Date { get; set; }
        string? Description { get; set; }
    }
}