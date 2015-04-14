using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Emoney.SQLHelper
{
    class SQLHelper1
    {
        public static void PrepareCommadn(SqlCommand ocmd, string conn, CommandType cmdType, string commdanText, SqlParameter[] param)
        {
            SqlConnection oconn = new SqlConnection(conn);
            if (!(oconn.State == ConnectionState.Open))
            {
                oconn.Open();
            }
            ocmd.CommandText = commdanText;
            ocmd.CommandType = cmdType;
            ocmd.Connection = oconn;
            if (param != null)
            {
                foreach (SqlParameter parm in param)
                {
                    if((parm.Direction==ParameterDirection.InputOutput) && (parm.Value==null))
                    {
                        parm.Value=
                        .Value;
                    }
                    ocmd.Parameters.Add(parm);
                }
            }
        }
    }

}
