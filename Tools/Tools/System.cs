
namespace System
{
    public static class DataTimeExtension
    {
        public static string ToDateTimeFormat(this DateTime d) => d.ToString("yyyy-MM-dd HH:mm:ss.fff");
        public static string ToDateFormat(this DateTime d) => d.ToString("yyyy-MM-dd");
        public static string ToTimeFormat(this DateTime d) => d.ToString("HH:mm:ss.fff");

    }
}
