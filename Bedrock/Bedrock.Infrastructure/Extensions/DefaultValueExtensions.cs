namespace Bedrock.Infrastructure.Extensions
{
    public static class DefaultValueExtensions
    {
        public static string Default(this string current, string defaultValue = "")
        {
            return current != null
                ? current
                : defaultValue;
        }

        public static int Default(this int? current, int defaultValue = 0)
        {
            return !current.HasValue
                ? current.Value
                : defaultValue;
        }

        public static double Default(this double? current, double defaultValue = 0.0)
        {
            return !current.HasValue
                ? current.Value
                : defaultValue;
        }

        public static bool Default(this bool? current, bool defaultValue = false)
        {
            return !current.HasValue
                ? current.Value
                : defaultValue;
        }
    }
}
