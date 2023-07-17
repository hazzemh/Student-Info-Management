using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Management.DBServices
{
    interface IDBService
    {
        int executeQuery(SqlCommand command);
    }
}
