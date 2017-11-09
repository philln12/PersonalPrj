using DbConnect.Adapter;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PersonalProject.Services
{
    public class BaseService
    {
        public IDbAdapter Adapter
        {
            get
            {
                return new DbAdapter(new SqlCommand(), new SqlConnection("Server=PHILLN12\\SQLEXPRESS01;Database=DB1;Trusted_Connection=True;"));
                //return new DbAdapter(new SqlCommand(), new SqlConnection("Server=PHILLN12\SQLEXPRESS01;Database=C41_OrganicKarma;User Id=C41_User;Password=Sabiopass1!"));
            }

        }
    }
}