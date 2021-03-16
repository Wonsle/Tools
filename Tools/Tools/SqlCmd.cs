using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace Tools
{
    public class SqlCmd
    {
        private string connStr = "";
        private SqlConnection sqc;
        private SqlCommand cmd;
        private SqlTransaction tran;
        private SqlDataAdapter dataAdpater;
        public SqlCmd()
        {

        }
        private void OpenConn()
        {
            if (cmd == null)
                sqc = new SqlConnection(connStr);
            if (sqc.State != ConnectionState.Open)
                sqc.Open();

        }
        private void CloseConn()
        {

            if (sqc.State != ConnectionState.Closed)
                sqc.Open();
            sqc.Dispose();
            sqc = null;
        }

        public int ExecuteNonQuery(string sql)
        {
            int result = 0;
            OpenConn();
            try
            {
                cmd.CommandText = sql;
                result = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                CloseConn();
                throw (ex);
            }
            CloseConn();
            return result;

        }
        public object ExecuteScalar(string sql)
        {
            object result = 0;
            OpenConn();
            try
            {
                cmd.CommandText = sql;
                result = cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                CloseConn();
                throw (ex);
            }
            CloseConn();
            return result;

        }
        public DataTable ExecuteDataTable(string sql)
        {

            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            OpenConn();
            try
            {
                dataAdpater = new SqlDataAdapter(cmd);
                dataAdpater.FillSchema(ds, SchemaType.Source);
                dataAdpater.Fill(ds);
                dt = ds.Tables[0];
            }
            catch(Exception ex)
            {
                CloseConn();
                throw (ex);
            }
            CloseConn();
            return dt;
        }
        public int ExecuteNonQueryTran(string sql)
        {
           
            int result = 0;
            OpenConn();
            tran = sqc.BeginTransaction();
            cmd.Transaction = tran;
            try
            {
                cmd.CommandText = sql;
                result = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                CloseConn();
                throw (ex);
            }
            CloseConn();
            return result;
        }
    }
}
