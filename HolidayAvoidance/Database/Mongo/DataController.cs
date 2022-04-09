using Realms; 

namespace HolidayAvoidance
{
    internal static class DataController
    {
        public static Realm GetNewDBRealm(string databaseName)
        {
            return Realm.GetInstance(new DatabaseConfigurationFactory(databaseName)); 
        }
    }
}
