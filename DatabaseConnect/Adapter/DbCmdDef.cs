using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConnect.Adapter
{
    public class DbCmdDef : IDbCmdDef
    {
        public string DbCommandText { get; set; }
        //name of the stored procedure
        public CommandType DbCommandType { get; set; }

        public IDbDataParameter[] DbParameters { get; set; }
       
    }
}
