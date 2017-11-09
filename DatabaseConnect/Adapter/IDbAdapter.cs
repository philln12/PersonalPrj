using System.Data;

namespace DatabaseConnect.Adapter
{
    public interface IDbAdapter
    {
        int CommandTimeout { get; set; }
        IDbCommand DbCommand { get; }
        IDbConnection DbConnection { get; }

        int ExecuteQuery(IDbCmdDef cmdDef, System.Action<IDataParameterCollection> returnParameters = null);
        object ExecuteScalar(IDbCmdDef cmdDef);
        System.Collections.Generic.IEnumerable<T> LoadObject<T>(IDbCmdDef cmdDef) where T : class;
        System.Collections.Generic.IEnumerable<T> LoadObject<T>(IDbCmdDef cmdDef, System.Func<IDataReader, T> mapper) where T : class;
    }
}