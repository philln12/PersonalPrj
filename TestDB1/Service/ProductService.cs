
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
    public class ProductService
    {
        private IDbAdapter Adapter
        {
            get
            {
                return new DbAdapter(new SqlCommand(), new SqlConnection("Server=13.64.246.7;Database=C41_OrganicKarma;User Id=C41_User;Password=Sabiopass1!"));
            }
        }
        public IEnumerable<Product> GetAllProducts()
        {
            DbCmdDef cmdDef = new DbCmdDef
            {
                DbCommandText = "dbo.Product_SelectAll",
                DbCommandType = System.Data.CommandType.StoredProcedure,
                DbParameters = new[]
                {
                    SqlDbParameter.Instance.BuildParameter("@DisplayActive", true, System.Data.SqlDbType.Bit)
                }
            };
            return Adapter.LoadObject<Product>(cmdDef);
        }
        public Product GetById(int id)
        {
            try
            {
                return Adapter.LoadObject<Product>(new DbCmdDef
                {
                    DbCommandText = "dbo.Product_SelectById",
                    DbCommandType = System.Data.CommandType.StoredProcedure,
                    DbParameters = new[]
                    {
                        SqlDbParameter.Instance.BuildParameter("@Id", id, System.Data.SqlDbType.Int)

                    }

                }).FirstOrDefault();
            }
            catch
            {
                throw;
            }
        }


    }
}