using Newtonsoft.Json;
using Slack.NetStandard.JsonConverters;

namespace Slack.NetStandard.Messages.Elements
{
    [JsonConverter(typeof(OptionConverter))]
    public interface IOption
    {
    }

    public static class OptionExtensions
    {
        public static Option AsOption(this IOption option)
        {
            return option as Option;
        }

        public static OptionGroup AsOptionGroup(this IOption option)
        {
            return option as OptionGroup;
        }
    }
}