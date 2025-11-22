using Newtonsoft.Json;
using System.Collections.Generic;

namespace Slack.NetStandard.WebApi.SlackLists.CellDefinition
{
    public class PhoneCellDefinition:SlackListsCellDefinition
    {
        public PhoneCellDefinition(string columnId, string rowId = null) : base(columnId, rowId) { }

        public PhoneCellDefinition(string columnId, List<string> phoneNumbers, string rowId = null) : this(columnId, rowId)
        {
            PhoneNumbers = phoneNumbers;
        }

        [JsonProperty("phone")]
        public List<string> PhoneNumbers { get; private set; } = new();

        public bool ShouldSerializePhoneNumbers() => true;
    }
}
