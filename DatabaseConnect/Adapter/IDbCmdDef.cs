using System.Data;

namespace DatabaseConnect.Adapter
{
    public interface IDbCmdDef
    {
        string DbCommandText { get; set; }
        CommandType DbCommandType { get; set; }
        IDbDataParameter[] DbParameters { get; set; }
    }
}