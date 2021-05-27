using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Common;

namespace Tools
{
    public static class DbCmdExtension
    {
        public static char GetChar(this DbDataReader d, string s) => d.GetChar(d.GetOrdinal(s));
        public static string GetString(this DbDataReader d, string s) => d.GetString(d.GetOrdinal(s));
        public static short GetInt16(this DbDataReader d, string s) => d.GetInt16(d.GetOrdinal(s));
        public static int GetInt32(this DbDataReader d, string s) => d.GetInt32(d.GetOrdinal(s));
        public static long GetInt64(this DbDataReader d, string s) => d.GetInt64(d.GetOrdinal(s));
        public static decimal GetDecimal(this DbDataReader d, string s) => d.GetDecimal(d.GetOrdinal(s));
        public static double GetDouble(this DbDataReader d, string s) => d.GetDouble(d.GetOrdinal(s));
        public static float GetFloat(this DbDataReader d, string s) => d.GetFloat(d.GetOrdinal(s));
        public static bool GetBoolean(this DbDataReader d, string s) => d.GetBoolean(d.GetOrdinal(s));
        public static Guid GetGuid(this DbDataReader d, string s) => d.GetGuid(d.GetOrdinal(s));
        public static DateTime GetDateTime(this DbDataReader d, string s) => d.GetDateTime(d.GetOrdinal(s));
        public static DbDataReader GetData(this DbDataReader d, string s) => d.GetData(d.GetOrdinal(s));
        public static System.IO.Stream GetStream(this DbDataReader d, string s) => d.GetStream(d.GetOrdinal(s));
        public static string GetName(this DbDataReader d, string s) => d.GetName(d.GetOrdinal(s));



        public static bool IsDBNull(this DbDataReader d, string s) => d.IsDBNull(d.GetOrdinal(s));
    }
}
