namespace HolidayAvoidance
{
    public class HolidayManager
    {
        /// <summary>
        /// Add a holiday to the database  
        /// </summary>
        /// <param name="holiday"></param>
        /// <param name="addHolidayCallback"></param>
        /// <param name="databaseName">Name of the database to access</param>
        public void AddHoliday(IHoliday holiday, Action? addHolidayCallback = null, string databaseName = "holidaydb.realm")
        {
            var resultHoliday = (Holiday)holiday; 
            var realm = DataController.GetNewDBRealm(databaseName);
            realm.Write(() =>
            {
                realm.Add(resultHoliday); 
            });
            if(addHolidayCallback is not null)
            {
                addHolidayCallback(); 
            }
        }

        /// <summary>
        /// Remove a loliday from the database 
        /// </summary>
        /// <param name="holiday"></param>
        /// <param name="removeHolidayCallback"></param>
        /// <param name="databaseName">Name of the database to access</param>
        public void RemoveHoliday(IHoliday holiday, Action? removeHolidayCallback = null, string databaseName = "holidaydb.realm")
        {
            var resultHoliday = (Holiday)holiday; 
            var realm = DataController.GetNewDBRealm(databaseName);
            realm.Write(() =>
            {
                realm.Remove(resultHoliday); 
            }); 
            if(removeHolidayCallback is not null)
            {
                removeHolidayCallback(); 
            }
        }

        /// <summary>
        /// Update a holiday by passing in the holiday to update, the new date value, and the new description value
        /// </summary>
        /// <param name="holidayToUpdate"></param>
        /// <param name="date"></param>
        /// <param name="description"></param>
        /// <param name="avoidanceAction"></param>
        /// <param name="completionCallback"></param>
        /// <param name="databaseName">Name of the database to access</param>
        public void UpdateHoliday(IHoliday holidayToUpdate, DateTime date, string? description = "", HolidayAvoidanceAction avoidanceAction = HolidayAvoidanceAction.MoveForwardOneDay, Action? completionCallback = null, string databaseName = "holidaydb.realm")
        {
            var resultHoliday = (Holiday)holidayToUpdate;
            var realm = DataController.GetNewDBRealm(databaseName);
            realm.Write(() =>
            {
                resultHoliday.Date = date;
                resultHoliday.Description = description;
                resultHoliday.AvoidanceAction = avoidanceAction; 
            });
            if(completionCallback is not null)
            {
                completionCallback(); 
            }
        }
    }
}
