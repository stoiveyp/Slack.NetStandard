using System.Collections.Generic;
using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Admin
{
    public class Barrier
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("enterprise_id",NullValueHandling = NullValueHandling.Ignore)]
        public string EnterpriseId { get; set; }

        [JsonProperty("primary_usergroup")]
        public IdpGroup PrimaryUserGroup { get; set; }

        [JsonProperty("barriered_from_usergroups"), AcceptedArray]
        public IdpGroup[] BarrieredFromUserGroups { get; set; }

        [JsonProperty("restricted_subjects"),AcceptedArray]
        public string[] RestrictedSubjects { get; set; }

        [JsonProperty("date_update")]
        public long DateUpdated { get; set; }

        public static List<string> AllThreeRestrictedSubjects() => new (){ "im", "mpim", "call" };
    }
}
