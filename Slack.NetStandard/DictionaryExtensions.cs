using System.Collections.Generic;

namespace Slack.NetStandard
{
    internal static class DictionaryExtensions
    {
        public static Dictionary<string, string> AddIfValue(this Dictionary<string, string> dict, string name,
            string value)
        {
            dict ??= new Dictionary<string, string>();

            if (string.IsNullOrWhiteSpace(value))
            {
                return dict;
            }

            dict.Add(name, value);
            return dict;
        }

        public static Dictionary<string, string> AddIfValue(this Dictionary<string, string> dict, string name,
            bool? value)
        {
            return dict.AddIfValue(name, value.GetValueOrDefault().ToString().ToLower());
        }

        public static Dictionary<string, string> AddIfValue(this Dictionary<string, string> dict, string name,
            int? value)
        {
            return dict.AddIfValue(name, value.GetValueOrDefault().ToString());
        }
        
        public static Dictionary<string, string> AddIfValue(this Dictionary<string, string> dict, string name,
            long? value)
        {
            return dict.AddIfValue(name, value.GetValueOrDefault().ToString());
        }

        public static Dictionary<string, string> AddPaging(this Dictionary<string, string> dict, string cursor,
            int? limit)
        {
            dict.AddIfValue("cursor", cursor);
            return dict.AddIfValue("limit", limit);
        }
    }
}