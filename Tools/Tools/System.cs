
namespace System
{
    public static class DataTime
    {
        public const string datetimeformat = "yyyy-MM-dd hh:mm:ss";
        public const string datetimeformatEx = datetimeformat + ".fff";
        public static string ToString(this DateTime d, string format = datetimeformat) => d.ToString(format);
    }
}
