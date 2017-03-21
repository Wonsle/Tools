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
        public static char GetChar(this SqlDataReader d, string s) => d.GetChar(d.GetOrdinal(s));
        public static string GetString(this SqlDataReader d, string s) => d.GetString(d.GetOrdinal(s));
        public static short GetInt16(this SqlDataReader d, string s) => d.GetInt16(d.GetOrdinal(s));
        public static int GetInt32(this SqlDataReader d, string s) => d.GetInt32(d.GetOrdinal(s));
        public static long GetInt64(this SqlDataReader d, string s) => d.GetInt64(d.GetOrdinal(s));
        public static decimal GetDecimal(this SqlDataReader d, string s) => d.GetDecimal(d.GetOrdinal(s));
        public static double GetDouble(this SqlDataReader d, string s) => d.GetDouble(d.GetOrdinal(s));
        public static float GetFloat(this SqlDataReader d, string s) => d.GetFloat(d.GetOrdinal(s));
        public static bool GetBoolean(this SqlDataReader d, string s) => d.GetBoolean(d.GetOrdinal(s));
        public static Guid GetGuid(this SqlDataReader d, string s) => d.GetGuid(d.GetOrdinal(s));
        public static DateTime GetDateTime(this SqlDataReader d, string s) => d.GetDateTime(d.GetOrdinal(s));
        public static TimeSpan GetTimeSpan(this SqlDataReader d, string s) => d.GetTimeSpan(d.GetOrdinal(s));
        public static DbDataReader GetData(this SqlDataReader d, string s) => d.GetData(d.GetOrdinal(s));
        public static System.IO.Stream GetStream(this SqlDataReader d, string s) => d.GetStream(d.GetOrdinal(s));
        public static string GetName(this SqlDataReader d, string s) => d.GetName(d.GetOrdinal(s));



        public static bool IsDBNull(this SqlDataReader d, string s) => d.IsDBNull(d.GetOrdinal(s));
    }
}
