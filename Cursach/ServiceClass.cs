using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Cursach
{
    class ServiceClass
    {
        public static string connectionString = @"Data Source=(local);Initial Catalog=ambulance;Integrated Security=True";
        public static SqlConnection Connection { get; set; }
        public static List<Car> Cars { get; set; }
        public static User CurrUser { get; set; }
    }
}
