namespace HolidayAvoidance
{
    public static class HolidayAvoidanceSystem
    {
        /// <summary>
        /// Returns an enumerable list of holidays
        /// </summary>
        /// <param name="databaseName">Name of the database to access</param>
        /// <returns></returns>
        public static IEnumerable<IHoliday> GetAllHolidays(string databaseName = "holidaydb.realm")
        {
            var realm = DataController.GetNewDBRealm(databaseName);
            IEnumerable<Holiday> holidays = realm.All<Holiday>();
            return holidays; 
        }

        /// <summary>
        /// Returns a date by subtracting a number of days while avoiding holidays. 
        /// </summary>
        /// <param name="date"></param>
        /// <param name="days"></param>
        /// <param name="avoidanceAction"></param>
        /// <param name="alertCallback"></param>
        /// <param name="databaseName"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static DateTime GetDateBySubtracting(DateTime date, int days, HolidayAvoidanceAction avoidanceAction, Action? alertCallback = null, string databaseName = "holidaydb.realm")
        {
            var realm = DataController.GetNewDBRealm(databaseName);
            var holidays = GetAllHolidays();
            var resultdate = date.AddDays(-days);
            while (holidays.Where(h => h.Date == resultdate) is not null)
            {
                switch (avoidanceAction)
                {
                    case HolidayAvoidanceAction.MoveForwardOneDay:
                        {
                            resultdate.AddDays(1);
                        }
                        break;
                    case HolidayAvoidanceAction.MoveBackwardOneDay:
                        {
                            resultdate.AddDays(-1);
                        }
                        break;
                    case HolidayAvoidanceAction.Alert:
                        {
                            if (alertCallback is not null)
                            {
                                alertCallback();
                            }
                            return resultdate;
                        }
                    case HolidayAvoidanceAction.Exception:
                        throw new Exception("This date lands on a holiday");
                    default:
                        return resultdate;
                }
            }
            return resultdate;
        }

        /// <summary>
        /// Returns a date by adding a number of days while avoiding holidays. 
        /// </summary>
        /// <param name="date"></param>
        /// <param name="days"></param>
        /// <param name="avoidanceAction"></param>
        /// <param name="alertCallback"></param>
        /// <param name="databaseName"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static DateTime GetDateByAdding(DateTime date, int days, HolidayAvoidanceAction avoidanceAction, Action? alertCallback = null, string databaseName = "holidaydb.realm")
        {
            var realm = DataController.GetNewDBRealm(databaseName);
            var holidays = GetAllHolidays();
            var resultdate = date.AddDays(days); 
            while(holidays.Where(h => h.Date == resultdate) is not null)
            {
                switch (avoidanceAction)
                {
                    case HolidayAvoidanceAction.MoveForwardOneDay:
                        {
                            resultdate.AddDays(1); 
                        }
                        break;
                    case HolidayAvoidanceAction.MoveBackwardOneDay:
                        {
                            resultdate.AddDays(-1); 
                        }
                        break;
                    case HolidayAvoidanceAction.Alert:
                        {
                            if(alertCallback is not null)
                            {
                                alertCallback(); 
                            }
                            return resultdate; 
                        }
                    case HolidayAvoidanceAction.Exception:
                        throw new Exception("This date lands on a holiday"); 
                    default:
                        return resultdate; 
                }
            }
            return resultdate; 
        }
    }
}
