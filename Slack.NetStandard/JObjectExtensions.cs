﻿using Newtonsoft.Json.Linq;

namespace Slack.NetStandard;

internal static class JObjectExtensions
{
    public static JObject AddIfValue(this JObject jo, string name, string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return jo;
        }

        jo ??= new JObject();
        jo.Add(new JProperty(name, value));


        return jo;
    }

    public static JObject AddIfValue<T>(this JObject jo, string name, T? value) where T : struct
    {
        if (!value.HasValue)
        {
            return jo;
        }

        jo ??= new JObject();
        jo.Add(new JProperty(name, value.Value));

        return jo;
    }

    public static JObject AddPaging(this JObject jo, string cursor, int? limit)
    {
        if (!string.IsNullOrWhiteSpace(cursor))
        {
            jo.Add("cursor", cursor);
        }

        if (limit.HasValue)
        {
            jo.Add("limit", limit.Value);
        }

        return jo;
    }
}