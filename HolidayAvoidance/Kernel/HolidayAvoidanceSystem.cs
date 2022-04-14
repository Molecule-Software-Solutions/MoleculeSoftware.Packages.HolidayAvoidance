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
        public static DateTimeOffset GetDateBySubtracting(DateTimeOffset date, int days, HolidayAvoidanceAction avoidanceAction, Action? alertCallback = null, string databaseName = "holidaydb.realm")
        {
            var realm = DataController.GetNewDBRealm(databaseName);
            var holidays = GetAllHolidays();
            var resultDate = date.AddDays(-days);

            while (DetermineIfHoliday(resultDate, databaseName) || DetermineIfWeekend(resultDate))
            {
                switch (avoidanceAction)
                {
                    case HolidayAvoidanceAction.MoveForwardOneDay:
                        {
                            resultDate = resultDate.AddDays(1);
                        }
                        break;
                    case HolidayAvoidanceAction.MoveBackwardOneDay:
                        {
                            resultDate = resultDate.AddDays(-1);
                        }
                        break;
                    case HolidayAvoidanceAction.Alert:
                        {
                            if (alertCallback is not null)
                            {
                                alertCallback();
                            }
                            return resultDate;
                        }
                    case HolidayAvoidanceAction.Exception:
                        throw new Exception("This date lands on a holiday");
                    default:
                        return resultDate;
                }
            }
            return resultDate;
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
        public static DateTimeOffset GetDateByAdding(DateTimeOffset date, int days, HolidayAvoidanceAction avoidanceAction, Action? alertCallback = null, string databaseName = "holidaydb.realm")
        {
            var realm = DataController.GetNewDBRealm(databaseName);
            var holidays = GetAllHolidays();
            var resultDate = date.AddDays(days); 

            while(DetermineIfHoliday(resultDate, databaseName) || DetermineIfWeekend(resultDate))
            {
                switch (avoidanceAction)
                {
                    case HolidayAvoidanceAction.MoveForwardOneDay:
                        {
                            resultDate = resultDate.AddDays(1); 
                        }
                        break;
                    case HolidayAvoidanceAction.MoveBackwardOneDay:
                        {
                            resultDate = resultDate.AddDays(-1); 
                        }
                        break;
                    case HolidayAvoidanceAction.Alert:
                        {
                            if(alertCallback is not null)
                            {
                                alertCallback(); 
                            }
                            return resultDate; 
                        }
                    case HolidayAvoidanceAction.Exception:
                        throw new Exception("This date lands on a holiday"); 
                    default:
                        return resultDate; 
                }
            }
            return resultDate; 
        }

        private static bool DetermineIfHoliday(DateTimeOffset date, string databaseName = "holidaydb.realm")
        {
            var controller = DataController.GetNewDBRealm(databaseName);
            var holidays = controller.All<Holiday>();
            if (holidays.Count() == 0)
                return false;
            var result = holidays?.FirstOrDefault(h => h.Date == date) is not null; 
            return result; 
        }

        private static bool DetermineIfWeekend(DateTimeOffset date)
        {
            if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                return true;
            return false; 
        }
    }
}
