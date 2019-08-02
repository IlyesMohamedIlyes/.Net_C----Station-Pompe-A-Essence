using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace StationServiceProject.Scripts
{
    class DatabaseAccess
    {
        private static DatabaseAccess _instance;
        public static DatabaseAccess Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new DatabaseAccess();

                return _instance;
            }
        }

        public DatabaseAccess()
        {//C:\StationService\Databases\
            //C:\Users\Ilyes\source\repos\StationServiceProject\StationServiceProject\Databases\
            Connection = new SqlConnection(
            @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ilyes\source\repos\StationServiceProject\StationServiceProject\Databases\StationServiceDatabase.mdf;Integrated Security=True"
            );
        }

        public SqlConnection Connection { get; private set; }
        
    }
}
