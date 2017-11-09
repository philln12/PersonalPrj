using DbConnect.Adapter;
using DbConnect.Tools;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDB1.Domain;

namespace TestDB1.Service
{
    public class PersonService
    {
        private IDbAdapter Adapter
        {
            get
            {
                return new DbAdapter(new SqlCommand(), new SqlConnection("Server=PHILLN12\\SQLEXPRESS01;Database=DB1;Trusted_Connection=True;"));
            }
        }
        public IEnumerable<Person> GetAllPersons()
        {
            DbCmdDef cmdDef = new DbCmdDef
            {
                DbCommandText = "dbo.People_SelectAll",
                DbCommandType = System.Data.CommandType.StoredProcedure
               
            };
            return Adapter.LoadObject<Person>(cmdDef);
        }
        


    }
}