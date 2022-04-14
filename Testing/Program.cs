using HolidayAvoidance; 

namespace Testing; 

public static class Program
{
    public static void Main()
    {
        Console.WriteLine("Beginning Testing");
        DateTimeOffset today = DateTime.Parse("04/13/2022");
        Console.WriteLine("Test date created"); 
        Console.WriteLine(today.Date.ToShortDateString()); 
        var result = HolidayAvoidanceSystem.GetDateByAdding(today, 10, HolidayAvoidanceAction.MoveForwardOneDay);
        Console.WriteLine("Result Calculated"); 
        Console.WriteLine(result);
        Console.WriteLine("Standard Tests Complete");

        // Adding result that is 10 days from today
        Console.WriteLine("Beginning Holiday Add");
        DateTimeOffset todayPlusTen = today.AddDays(10);
        Console.WriteLine("Create Holiday Manager"); 
        HolidayManager holidayManager = new HolidayManager();
        Console.WriteLine("Getting all previously recorded holidays"); 
        var holidaysRecorded = HolidayAvoidanceSystem.GetAllHolidays();
        Console.WriteLine("Printing those holidays");
        holidaysRecorded.ToList().ForEach((holiday) =>
        {
            Console.WriteLine(holiday.Date.ToString()); 
        }); 
        var testingHoliday = holidaysRecorded.Where(h => h.Date == todayPlusTen).FirstOrDefault();
        Console.WriteLine("Since the holiday did not exist it is being created"); 
        if(testingHoliday is null)
        {
            holidayManager.AddHoliday(new HolidayCustom()
            {
                AvoidanceAction = HolidayAvoidanceAction.MoveForwardOneDay,
                Date = todayPlusTen,
                Description = "Test Holiday"
            }); 
        }
        Console.WriteLine("Holiday add with new holiday is now calculating");
        DateTimeOffset todayPlusTenWithHoliday = HolidayAvoidanceSystem.GetDateByAdding(today, 10, HolidayAvoidanceAction.MoveForwardOneDay);
        Console.WriteLine("New result");
        Console.WriteLine(todayPlusTenWithHoliday.ToString());
        Console.WriteLine("DONE TESTING");

        Console.WriteLine("Now testing reverse calculation ======================");

        Console.WriteLine("Beginning Testing");
        DateTimeOffset revtoday = DateTime.Parse("04/13/2022");
        Console.WriteLine("Test date created");
        Console.WriteLine(revtoday.Date.ToShortDateString());
        var revresult = HolidayAvoidanceSystem.GetDateBySubtracting(today, 10, HolidayAvoidanceAction.MoveForwardOneDay);
        Console.WriteLine("Result Calculated");
        Console.WriteLine(revresult);
        Console.WriteLine("Standard Tests Complete");

        // Adding result that is 10 days from today
        Console.WriteLine("Beginning Holiday Add");
        DateTimeOffset revtodayPlusTen = today.AddDays(10);
        Console.WriteLine("Create Holiday Manager");
        HolidayManager revholidayManager = new HolidayManager();
        Console.WriteLine("Getting all previously recorded holidays");
        var revholidaysRecorded = HolidayAvoidanceSystem.GetAllHolidays();
        Console.WriteLine("Printing those holidays");
        revholidaysRecorded.ToList().ForEach((revholiday) =>
        {
            Console.WriteLine(revholiday.Date.ToString());
        });
        var revtestingHoliday = revholidaysRecorded.Where(h => h.Date == revtodayPlusTen).FirstOrDefault();
        Console.WriteLine("Since the holiday did not exist it is being created");
        if (revtestingHoliday is null)
        {
            revholidayManager.AddHoliday(new HolidayCustom()
            {
                AvoidanceAction = HolidayAvoidanceAction.MoveForwardOneDay,
                Date = revtodayPlusTen,
                Description = "Test Holiday"
            });
        }
        Console.WriteLine("Holiday add with new holiday is now calculating");
        DateTimeOffset revtodayPlusTenWithHoliday = HolidayAvoidanceSystem.GetDateBySubtracting(today, 10, HolidayAvoidanceAction.MoveForwardOneDay);
        Console.WriteLine("New result");
        Console.WriteLine(revtodayPlusTenWithHoliday.ToString());
        Console.WriteLine("DONE TESTING");
    }
}