using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Emoney.SQLHelper
{
    public class SQLHelper
    {
        #region 获取结果集
        /// <summary>
        /// 获取结果集
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="cmdType"></param>
        /// <param name="commandText"></param>
        /// <returns></returns>
        public static DataSet GetDataSet(string conn, CommandType cmdType, string commandText)
        {
            try
            {
                SqlCommand ocmd = new SqlCommand();
                PrepareCommand(ocmd, conn, cmdType, commandText, null);
                SqlDataAdapter od = new SqlDataAdapter(ocmd);
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                if (od.Fill(ds) > 0)
                {

                    return ds;
                }
                else
                {
                    return new DataSet();
                }

            }
            catch (Exception)
            {

                return new DataSet();
            }
        }
        #endregion

        #region 获取结果集
        /// <summary>
        /// 获取结果集
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="cmdType"></param>
        /// <param name="commandText"></param>
        /// <returns></returns>
        public static DataSet GetDataSet(string conn, CommandType cmdType, string commandText, SqlParameter[] parms)
        {
            try
            {
                SqlCommand ocmd = new SqlCommand();
                PrepareCommand(ocmd, conn, cmdType, commandText, parms);

                SqlDataAdapter od = new SqlDataAdapter(ocmd);
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                if (od.Fill(ds) > 0)
                {
                    return ds;
                }
                else
                {
                    return new DataSet();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region 执行增删改
        /// <summary>
        /// 执行增删改
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="cmdType"></param>
        /// <param name="commandText"></param>
        /// <returns></returns>
        public static int ExecuteNoQuery(string conn, CommandType cmdType, string commandText)
        {
            try
            {
                SqlCommand ocmd = new SqlCommand();
                PrepareCommand(ocmd, conn, cmdType, commandText, null);
                return ocmd.ExecuteNonQuery();

            }
            catch (Exception)
            {

                return 0;
            }
        }
        #endregion

        #region 执行增删改
        /// <summary>
        /// 执行增删改
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="cmdType"></param>
        /// <param name="commandText"></param>
        /// <returns></returns>
        public static int ExecuteNoQuery(string conn, CommandType cmdType, string commandText, SqlParameter[] parms)
        {
            try
            {
                SqlCommand ocmd = new SqlCommand();
                PrepareCommand(ocmd, conn, cmdType, commandText, parms);

                return ocmd.ExecuteNonQuery();

            }
            catch (Exception)
            {

                return 0;
            }
        }
        #endregion

        #region GetDataReader
        /// <summary>
        /// GetDataReader
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="cmdType"></param>
        /// <param name="commandText"></param>
        /// <param name="parms"></param>
        /// <returns></returns>
        public static SqlDataReader GetDataReader(string conn, CommandType cmdType, string commandText, SqlParameter[] parms)
        {
            try
            {
                SqlCommand ocmd = new SqlCommand();
                PrepareCommand(ocmd, conn, cmdType, commandText, parms);
                return ocmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception)
            {

                return null;
            }
        }
        #endregion

        #region GetDataReader
        /// <summary>
        /// GetDataReader
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="cmdType"></param>
        /// <param name="commandText"></param>
        /// <param name="parms"></param>
        /// <returns></returns>
        public static SqlDataReader GetDataReader(string conn, CommandType cmdType, string commandText)
        {
            try
            {
                SqlCommand ocmd = new SqlCommand();
                PrepareCommand(ocmd, conn, cmdType, commandText, null);
                return ocmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception)
            {

                return null;
            }
        }
        #endregion

        #region ExecuteScalar
        /// <summary>
        /// ExecuteScalar
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="cmdType"></param>
        /// <param name="commandText"></param>
        /// <param name="parms"></param>
        /// <returns></returns>
        public static object ExecuteScalar(string conn, CommandType cmdType, string commandText, SqlParameter[] parms)
        {
            try
            {
                SqlCommand ocmd = new SqlCommand();
                PrepareCommand(ocmd, conn, cmdType, commandText, parms);
                return ocmd.ExecuteScalar();
            }
            catch (Exception)
            {

                return null;
            }
        }
        #endregion

        #region ExecuteScalar
        /// <summary>
        /// ExecuteScalar
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="cmdType"></param>
        /// <param name="commandText"></param>
        /// <param name="parms"></param>
        /// <returns></returns>
        public static object ExecuteScalar(string conn, CommandType cmdType, string commandText)
        {
            try
            {
                SqlCommand ocmd = new SqlCommand();
                PrepareCommand(ocmd, conn, cmdType, commandText, null);
                return ocmd.ExecuteScalar();
            }
            catch (Exception)
            {

                return null;
            }
        }
        #endregion

        #region 封装Command
        /// <summary>
        /// 
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="cmdType"></param>
        /// <param name="commandText"></param>
        /// <param name="parms"></param>
        private static void PrepareCommand(SqlCommand ocmd, string conn, CommandType cmdType, string commandText, SqlParameter[] parms)
        {
            SqlConnection oconn = new SqlConnection(conn);
            if (!(oconn.State == ConnectionState.Open))
            {
                oconn.Open();
            }
            ocmd.CommandType = cmdType;
            ocmd.CommandText = commandText;
            ocmd.Connection = oconn;
            if (parms != null)
            {
                foreach (SqlParameter parm in parms)
                {
                    if ((parm.Direction == ParameterDirection.InputOutput) && (parm.Value == null))
                    {
                        parm.Value = DBNull.Value;

                    }
                    ocmd.Parameters.Add(parm);
                }
            }

        }
        #endregion
    }
}
