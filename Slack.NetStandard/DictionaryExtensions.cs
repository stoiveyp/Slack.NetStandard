using System;
using System.Collections.Generic;
using System.Text;

namespace Slack.NetStandard
{
    internal static class DictionaryExtensions
    {
        public static Dictionary<string, string> AddIfValue(this Dictionary<string, string> dict, string name, string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return dict;
            }

            dict ??= new Dictionary<string, string>();

            dict.Add(name, value);


            return dict;
        }

        public static Dictionary<string, string> AddIfValue<T>(this Dictionary<string, string> dict, string name, T? value) where T : struct
        {
            if (!value.HasValue)
            {
                return dict;
            }

            dict ??= new Dictionary<string, string>();

            if (value is bool?)
            {
                dict.Add(name, value.Value.ToString().ToLower());
            }
            else
            {
                dict.Add(name, value.Value.ToString());
            }

            return dict;
        }

        public static Dictionary<string, string> AddPaging(this Dictionary<string, string> dict, string cursor,
            int? limit)
        {
            if (!string.IsNullOrWhiteSpace(cursor))
            {
                dict.Add("cursor", cursor);
            }

            if (limit.HasValue)
            {
                dict.Add("limit", limit.Value.ToString());
            }

            return dict;
        }
    }
}
