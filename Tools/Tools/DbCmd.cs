using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Data.Common;
using System.Configuration;

namespace Tools
{
    public abstract class DbCmd
    {
        private string connStr = ConfigurationManager.ConnectionStrings[0].ConnectionString.Trim();
        public virtual DbProviderFactory dbProvierFactory { get; }
        private DbConnection sqc;
        private DbCommand cmd;
        private DbTransaction tran;
        private DbDataAdapter dataAdpater;

        public DbCmd()
        {

        }
        private void OpenConn()
        {
            if (sqc == null)
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

        private void PrepareCmd(string sql, CommandType cmdType = CommandType.Text, DbParameter[] dbParams = null)
        {
            OpenConn();
            cmd = dbProvierFactory.CreateCommand();
            cmd.CommandText = sql;
            cmd.Connection = sqc;
            cmd.CommandType = cmdType;
            if (dbParams != null && dbParams.Length > 0)
            {
                cmd.Parameters.Clear();
                cmd.Parameters.AddRange(dbParams);

            }
        }
        public int ExecuteNonQuery(string sql, CommandType cmdType, bool isTransaction = false, DbParameter[] dbParams = null)
        {
            int result = 0;
            PrepareCmd(sql, cmdType, dbParams);
            if (isTransaction)
            {
                tran = sqc.BeginTransaction();
                cmd.Transaction = tran;
            }
            try
            {
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
        public object ExecuteScalar(string sql, CommandType cmdType, DbParameter[] dbParams = null)
        {
            object result = 0;
            PrepareCmd(sql, cmdType, dbParams);

            try
            {
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
        public DataTable ExecuteDataTable(string sql, CommandType cmdType, DbParameter[] dbParams = null)
        {

            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            PrepareCmd(sql, cmdType, dbParams);
            try
            {
                dataAdpater = dbProvierFactory.CreateDataAdapter();
                dataAdpater.SelectCommand = cmd;
                dataAdpater.FillSchema(ds, SchemaType.Source);
                dataAdpater.Fill(ds);
                dt = ds.Tables[0];
            }
            catch (Exception ex)
            {
                CloseConn();
                throw (ex);
            }
            CloseConn();
            return dt;
        }

        public DbDataReader ExecuteReader(string sql, CommandType cmdType, DbParameter[] dbParams = null)
        {
            PrepareCmd(sql, cmdType, dbParams);
            DbDataReader sdr = cmd.ExecuteReader();
            CloseConn();
            return sdr;
        }

    }
}
