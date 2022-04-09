using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Realms; 

namespace HolidayAvoidance
{
    internal class DatabaseConfigurationFactory : RealmConfiguration
    {
        private string m_DatabasePath; 
        public DatabaseConfigurationFactory(string databaseName)
        {
            m_DatabasePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"{databaseName}");
            DatabasePath = m_DatabasePath; 
            MigrationCallback = (migration, oldMigrationNumber) =>
            {
                // Insert Migrations Here
            };
        }
    }
}
